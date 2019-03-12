namespace AbpLearning.Application.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Entities;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using Abp.Localization;
    using Abp.Runtime.Session;
    using AbpLearning.Application.Authorization.Roles.Dto;
    using AbpLearning.Application.Base;
    using Core;
    using Core.Authorization.Roles;
    using Core.Authorization.Users;
    using Dto;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    [AbpAuthorize(AbpLearningPermissions.User)]
    public class UserAppService : CrudAsyncAppService<User, long, UserGetViewOutput, UserGetPagedOutput, UserGetPagedInput, UserGetUpdateOutput, UserCreateInput, UserUpdateInput>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        protected override string NodePermissionName => AbpLearningPermissions.User;

        public UserAppService(
            IRepository<User, long> repository,
            UserManager userManager,
            RoleManager roleManager,
            IRepository<Role> roleRepository,
            IPasswordHasher<User> passwordHasher)
            : base(repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
        }

        public override async Task<NullableIdDto<long>> CreateAsync(UserCreateInput input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);

            user.TenantId = AbpSession.TenantId;
            user.Password = _passwordHasher.HashPassword(user, input.Password);
            user.IsEmailConfirmed = true;

            CheckErrors(await _userManager.CreateAsync(user));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            CurrentUnitOfWork.SaveChanges();

            return null;
        }

        public override async Task<NullableIdDto<long>> UpdateAsync(UserUpdateInput input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);

            ObjectMapper.Map(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            return null;
        }

        public override async Task DeleteAsync(NullableIdDto<long> input)
        {
            CheckDeletePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id.GetValueOrDefault());
            await _userManager.DeleteAsync(user);
        }

        public async Task<ListResultDto<RoleGetViewOutput>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleGetViewOutput>(ObjectMapper.Map<List<RoleGetViewOutput>>(roles));
        }

        public async Task ChangeLanguage(ChangeUserLanguageDto input)
        {
            await SettingManager.ChangeSettingForUserAsync(
                AbpSession.ToUserIdentifier(),
                LocalizationSettingNames.DefaultLanguage,
                input.LanguageName
            );
        }

        protected override IQueryable<User> CreateFilteredQuery(UserGetPagedInput input)
        {
            return Entities.Include(x => x.Roles).WhereIf(!input.FilterText.IsNullOrWhiteSpace(), m => m.UserName.Contains(input.FilterText));
        }

        protected async Task<User> GetEntityByIdAsync(long id)
        {
            var user = await Repository.GetAllIncluding(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new EntityNotFoundException(typeof(User), id);
            }

            return user;
        }
    }
}
