namespace AbpLearning.Application.Authorization.Roles
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Collections.Extensions;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using AbpLearning.Application.Authorization.Permissions;
    using Base;
    using Core;
    using Core.Authorization.Roles;
    using Dto;
    using Microsoft.EntityFrameworkCore;
    using AbpLearning.Common.Extensions;
    using AbpLearning.Application.Authorization.Permissions.Dto;

    [AbpAuthorize(AbpLearningPermissions.Role)]
    public class RoleAppService : CrudAsyncAppService<Role, int, RoleGetViewOutput, RoleGetPagedOutput, RoleGetPagedInput, RoleGetUpdateOutput, RoleCreateInput, RoleUpdateInput>, IRoleAppService
    {
        private readonly RoleManager _roleManager;

        private readonly IPermissionManager _permissionManager;

        public RoleAppService(RoleManager roleManager, IPermissionManager permissionManager, IRepository<Role, int> repository) : base(repository)
        {
            _roleManager = roleManager;
            _permissionManager = permissionManager;
        }

        protected override string NodePermissionName => AbpLearningPermissions.Role;

        /// <summary>
        /// Check Duplicate Role Name
        /// </summary>
        /// <param name="expectedRoleId"></param>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public bool CheckDuplicateRoleName(int? expectedRoleId, string name, string displayName)
        {
            return Repository.GetAll().AsNoTracking()
                .Where(m => m.Id != expectedRoleId.GetValueOrDefault())
                .Any(m => m.Name == name || m.DisplayName == displayName);
        }

        /// <summary>
        /// get all for role view model
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ListResultDto<RoleGetViewOutput>> GetAllForViewAsync(RoleGetViewInput input)
        {
            var entities = await _roleManager.Roles
                .WhereIf(!input.PermissionName.IsNullOrEmpty(), m => m.Permissions.Any(p => p.Name.Contains(input.PermissionName) && p.IsGranted)
                ).ToListAsync();

            return new ListResultDto<RoleGetViewOutput>(ObjectMapper.Map<List<RoleGetViewOutput>>(entities));
        }

        public override async Task<NullableIdDto<int>> CreateAsync(RoleCreateInput input)
        {
            CheckCreatePermission();

            var role = new Role(AbpSession.TenantId, input.Name, input.DisplayName)
            {
                IsDefault = input.IsDefault
            };

            CheckErrors(await _roleManager.CreateAsync(role));

            await CurrentUnitOfWork.SaveChangesAsync();

            var grantedPermissions = _permissionManager.GetAllPermissionsByNames(input.GrantedPermissions);

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            return ObjectMapper.Map<NullableIdDto>(null);
        }

        public override async Task<NullableIdDto<int>> UpdateAsync(RoleUpdateInput input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.Role.Id);

            role.IsDefault = input.Role.IsDefault;
            role.Description = input.Role.Description;
            role.DisplayName = input.Role.DisplayName;

            await _roleManager.UpdateAsync(role);

            var permissions = _permissionManager.GetAllPermissionsByNames(input.GrantedPermission);

            await _roleManager.SetGrantedPermissionsAsync(role, permissions);

            return ObjectMapper.Map<NullableIdDto>(null);
        }

        public override async Task<RoleGetUpdateOutput> GetUpdateAsync(EntityDto<int> input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.Id);

            var roleUpdate = ObjectMapper.Map<RoleUpdateDto>(role);

            var permissions = _permissionManager.GetAllPermissions();

            var grantedPermission = await _roleManager.GetGrantedPermissionsAsync(input.Id);

            return new RoleGetUpdateOutput()
            {
                Role = roleUpdate,
                Permissions = ObjectMapper.Map<List<PermissionGetViewOutput>>(permissions),
                GrantedPermissionNames = grantedPermission.Select(m => m.Name).ToList()
            };
        }

        protected override IQueryable<Role> CreateFilteredQuery(RoleGetPagedInput input)
        {
            var query = Repository.GetAll().AsNoTracking()
                .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), m => m.Name.Contains(input.FilterText))
                .WhereIf(input.PermissionNames?.Count() > 0, m => m.Permissions.Any(p => input.PermissionNames.Contains(p.Name) && p.IsGranted));

            return query;
        }
    }
}
