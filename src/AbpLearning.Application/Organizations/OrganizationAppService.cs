namespace AbpLearning.Application.Organizations
{
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Authorization.Users;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using Abp.Organizations;
    using Abp.UI;
    using Base;
    using Core;
    using Dto;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="OrganizationAppService" />
    /// </summary>
    [AbpAuthorize(AbpLearningPermissions.Organization)]
    public class OrganizationAppService : AbpLearningAppServiceBase, IOrganizationAppService
    {
        /// <summary>
        /// Defines the _organizationUnitManager
        /// </summary>
        private readonly OrganizationUnitManager _organizationUnitManager;

        /// <summary>
        /// Defines the _organizationUnitRepository
        /// </summary>
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;

        /// <summary>
        /// Defines the _userOrganizationUnitRepository
        /// </summary>
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationAppService"/> class.
        /// </summary>
        /// <param name="organizationUnitManager">The organizationUnitManager<see cref="OrganizationUnitManager"/></param>
        /// <param name="organizationUnitRepository">The organizationUnitRepository<see cref="OrganizationUnit"/></param>
        /// <param name="userOrganizationUnitRepository">The userOrganizationUnitRepository<see cref="UserOrganizationUnit"/></param>
        public OrganizationAppService(OrganizationUnitManager organizationUnitManager, IRepository<OrganizationUnit, long> organizationUnitRepository, IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository)
        {
            _organizationUnitManager = organizationUnitManager;
            _organizationUnitRepository = organizationUnitRepository;
            _userOrganizationUnitRepository = userOrganizationUnitRepository;
        }

        /// <summary>
        /// The CreateAsync
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationCreateInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        [AbpAuthorize(AbpLearningPermissions.Organization + AbpLearningPermissions.Action.Create)]
        public async Task CreateAsync(OrganizationCreateInput input)
        {
            input.TenantId = AbpSession.TenantId;
            var organization = ObjectMapper.Map<OrganizationUnit>(input);

            await _organizationUnitManager.CreateAsync(organization);
        }

        /// <summary>
        /// The DeleteAsync
        /// </summary>
        /// <param name="input">The input<see cref="EntityDto"/></param>
        /// <returns>The <see cref="Task"/></returns>
        [AbpAuthorize(AbpLearningPermissions.Organization + AbpLearningPermissions.Action.Delete)]
        public async Task DeleteAsync(EntityDto<long> input)
        {
            await _organizationUnitManager.DeleteAsync(input.Id);
        }

        /// <summary>
        /// The GetListAsync
        /// </summary>
        /// <returns>The <see cref="ListResultDto{OrganizationGetTreeOutput}"/></returns>
        [AbpAuthorize(AbpLearningPermissions.Organization + AbpLearningPermissions.Action.Query)]
        public async Task<ListResultDto<OrganizationGetListDto>> GetListAsync()
        {
            var query = from organization in _organizationUnitRepository.GetAll().AsNoTracking()
                        join organizationUser in _userOrganizationUnitRepository.GetAll().AsNoTracking() on organization.Id equals organizationUser.OrganizationUnitId into user
                        select new OrganizationGetListDto
                        {
                            Id = organization.Id,
                            ParentId = organization.ParentId,
                            Code = organization.Code,
                            DisplayName = organization.DisplayName,
                            MemberCount = user.Count(),
                        };

            var items = await query.ToListAsync();

            return new ListResultDto<OrganizationGetListDto>(items);
        }

        /// <summary>
        /// The MoveAsync
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationMoveInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        [AbpAuthorize(AbpLearningPermissions.Organization + AbpLearningPermissions.Action.Update)]
        public async Task MoveAsync(OrganizationMoveInput input)
        {
            await _organizationUnitManager.MoveAsync(input.OrganizationOldParentId, input.OrganizationNewParentId);
        }

        /// <summary>
        /// The GetUpdateAsync
        /// </summary>
        /// <param name="input">The input<see cref="EntityDto"/></param>
        /// <returns>The <see cref="Task{OrganizationGetUpdateOutput}"/></returns>
        public async Task<OrganizationGetUpdateDto> GetUpdateAsync(EntityDto<long> input)
        {
            var entity = await _organizationUnitRepository.GetAsync(input.Id);

            if (entity == null)
            {
                throw new UserFriendlyException(L("NotFoundData"));
            }

            return ObjectMapper.Map<OrganizationGetUpdateDto>(entity);
        }

        /// <summary>
        /// The UpdateAsync
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationUpdateInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        [AbpAuthorize(AbpLearningPermissions.Organization + AbpLearningPermissions.Action.Update)]
        public async Task UpdateAsync(OrganizationUpdateInput input)
        {
            var entity = await _organizationUnitRepository.GetAsync(input.Id);

            if (entity == null)
            {
                throw new UserFriendlyException(L("NotFoundData"));
            }

            await _organizationUnitRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// The AddUser2OrganizationAsync
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationUserInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task AddUser2OrganizationAsync(OrganizationUserInput input)
        {
            await UserManager.AddToOrganizationUnitAsync(input.UserIds.First(), input.OrganizationId);
        }

        /// <summary>
        /// The RemoveUser2OrganizationAsync
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationUserInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task RemoveUser2OrganizationAsync(OrganizationUserInput input)
        {
            foreach (var user in input.UserIds)
            {
                await UserManager.RemoveFromOrganizationUnitAsync(user, input.OrganizationId);
            }
        }

        /// <summary>
        /// The GetPagedForUser
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationUserGetPagedInput"/></param>
        /// <returns>The <see cref="PagedResultDto{OrganizationUserGetPagedOutput}"/></returns>
        public async Task<PagedResultDto<OrganizationUserGetPagedOutput>> GetPagedForUser(OrganizationUserGetPagedInput input)
        {
            var query = from userOrganization in _userOrganizationUnitRepository.GetAll().AsNoTracking()
                        join user in UserManager.Users.AsNoTracking().WhereIf(!input.FilterText.IsNullOrEmpty(),
                                m => m.UserName.Contains(input.FilterText) || m.EmailAddress.Contains(input.FilterText))
                            on userOrganization.UserId equals user.Id
                        join organization in _organizationUnitRepository.GetAll().AsNoTracking() on userOrganization.OrganizationUnitId equals organization.Id
                        where organization.Id == input.OrganizationId
                        select new OrganizationUserGetPagedOutput
                        {
                            UserId = user.Id,
                            UserName = user.UserName,
                            EmailAddress = user.EmailAddress,
                            CreationTime = userOrganization.CreationTime
                        };

            var count = await query.CountAsync();

            var result = await query.PageBy(input).OrderBy(input.Sorting).ToListAsync();

            return new PagedResultDto<OrganizationUserGetPagedOutput>(count, result);
        }

        /// <summary>
        /// The GetAllForUser
        /// </summary>
        /// <param name="input">The input<see cref="PagedFilteringDtoBase"/></param>
        /// <returns>The <see cref="PagedResultDto{OrganizationUserGetAllOutput}"/></returns>
        public async Task<PagedResultDto<OrganizationUserGetAllOutput>> GetAllForUser(OrganizationUserGetAllInput input)
        {
            var query = UserManager.Users.AsNoTracking().WhereIf(!input.FilterText.IsNullOrEmpty(),
                    m => m.UserName.Contains(input.FilterText) || m.EmailAddress.Contains(input.FilterText))
                .Select(m => new OrganizationUserGetAllOutput
                {
                    UserId = m.Id,
                    UserName = m.UserName,
                    EmailAddress = m.EmailAddress,
                });

            var userOrganization = await _userOrganizationUnitRepository.GetAll().AsNoTracking()
                .Select(m => new { m.UserId, m.OrganizationUnitId }).ToListAsync();

            var organizationIds = userOrganization.Select(m => m.OrganizationUnitId).Distinct();

            var organization = await _organizationUnitRepository.GetAll().AsNoTracking()
                .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), m => m.DisplayName.Contains(input.FilterText))
                .Where(m => organizationIds.Contains(m.Id))
                .Select(m => new { m.Id, m.DisplayName }).ToListAsync();

            var count = await query.CountAsync();

            var result = await query.PageBy(input).OrderBy(input.Sorting).ToListAsync();

            foreach (var item in result)
            {
                var uo = userOrganization.Where(m => m.UserId == item.UserId).Select(m => m.OrganizationUnitId);

                if (uo.Any())
                {
                    item.OrganizationNames = organization.Where(m => uo.Contains(m.Id)).OrderBy(m => m.DisplayName).ToList()
                        .ConvertAll(m => m.DisplayName);
                }
            }

            return new PagedResultDto<OrganizationUserGetAllOutput>(count, result);
        }
    }
}
