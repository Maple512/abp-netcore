namespace AbpLearning.Application.Organizations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Authorization.Users;
    using Abp.Domain.Repositories;
    using Abp.Linq.Extensions;
    using Abp.Organizations;
    using Abp.UI;
    using AbpLearning.Core;
    using Dto;
    using Microsoft.EntityFrameworkCore;
    using Common.Extensions;

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
            var organization = ObjectMapper.Map<OrganizationUnit>(input);

            await _organizationUnitManager.CreateAsync(organization);
        }

        /// <summary>
        /// The DeleteAsync
        /// </summary>
        /// <param name="input">The input<see cref="EntityDto{long}"/></param>
        /// <returns>The <see cref="Task"/></returns>
        [AbpAuthorize(AbpLearningPermissions.Organization + AbpLearningPermissions.Action.Delete)]
        public async Task DeleteAsync(EntityDto<long> input)
        {
            await _organizationUnitManager.DeleteAsync(input.Id);
        }

        /// <summary>
        /// The GetTreeAsync
        /// </summary>
        /// <returns>The <see cref="ListResultDto{OrganizationGetTreeOutput}"/></returns>
        [AbpAuthorize(AbpLearningPermissions.Organization + AbpLearningPermissions.Action.Query)]
        public async Task<ListResultDto<OrganizationGetTreeOutput>> GetTreeAsync()
        {
            var query = from organization in _organizationUnitRepository.GetAll().AsNoTracking()
                        join organizationUser in _userOrganizationUnitRepository.GetAll().AsNoTracking() on organization.Id equals organizationUser.OrganizationUnitId into user
                        select new OrganizationGetTreeOutput
                        {
                            Id = organization.Id,
                            ParentId = organization.ParentId,
                            Code = organization.Code,
                            DisplayName = organization.DisplayName,
                            MemberCount = user.Count(),
                        };

            var items = await query.ToListAsync();

            return new ListResultDto<OrganizationGetTreeOutput>(items);
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
        /// <param name="input">The input<see cref="EntityDto{long}"/></param>
        /// <returns>The <see cref="Task{OrganizationGetUpdateOutput}"/></returns>
        public async Task<OrganizationGetUpdateOutput> GetUpdateAsync(EntityDto<long> input)
        {
            var entity = await _organizationUnitRepository.GetAsync(input.Id);

            if (entity == null)
            {
                throw new UserFriendlyException(L("NotFoundData"));
            }

            return ObjectMapper.Map<OrganizationGetUpdateOutput>(entity);
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

        #region Organization User

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
        /// <returns>The <see cref="Task{PagedResultDto{OrganizationUserGetPagedOutput}}"/></returns>
        public async Task<PagedResultDto<OrganizationUserGetPagedOutput>> GetPagedForUser(OrganizationUserGetPagedInput input)
        {
            var query = from userOrganization in _userOrganizationUnitRepository.GetAll().AsNoTracking()
                        join organization in _organizationUnitRepository.GetAll().AsNoTracking() on userOrganization.OrganizationUnitId equals organization.Id
                        join user in UserManager.Users.AsNoTracking() on userOrganization.UserId equals user.Id
                        where userOrganization.OrganizationUnitId == input.OrganizationId
                        select new OrganizationUserGetPagedOutput
                        {
                            UserId = user.Id,
                            CreationTime = userOrganization.CreationTime,
                            UserName = user.UserName
                        };

            var count = await query.CountAsync();

            var result = await query.PageBy(input).OrderBy(input.Sorting).ToListAsync();

            return new PagedResultDto<OrganizationUserGetPagedOutput>(count, result);
        }

        #endregion
    }
}
