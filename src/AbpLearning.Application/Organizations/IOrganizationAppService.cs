namespace AbpLearning.Application.Organizations
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Base;
    using Dto;

    /// <summary>
    /// Defines the <see cref="IOrganizationAppService" />
    /// </summary>
    public interface IOrganizationAppService : IApplicationService
    {
        /// <summary>
        /// The GetTreeAsync
        /// </summary>
        /// <returns>The <see cref="ListResultDto{OrganizationGetTreeOutput}"/></returns>
        Task<ListResultDto<OrganizationGetListDto>> GetListAsync();

        /// <summary>
        /// The GetUpdateAsync
        /// </summary>
        /// <param name="input">The input<see cref="EntityDto"/></param>
        /// <returns>The <see cref="Task{OrganizationGetUpdateOutput}"/></returns>
        Task<OrganizationGetUpdateDto> GetUpdateAsync(EntityDto<long> input);

        /// <summary>
        /// The CreateAsync
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationCreateInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task CreateAsync(OrganizationCreateInput input);

        /// <summary>
        /// The UpdateAsync
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationUpdateInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task UpdateAsync(OrganizationUpdateInput input);

        /// <summary>
        /// The DeleteAsync
        /// </summary>
        /// <param name="input">The input<see cref="EntityDto"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// The MoveAsync
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationMoveInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task MoveAsync(OrganizationMoveInput input);

        Task<PagedResultDto<OrganizationUserGetAllOutput>> GetAllForUser(OrganizationUserGetAllInput input);

        /// <summary>
        /// The GetPagedForUser
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationUserGetPagedInput"/></param>
        /// <returns>The <see cref="PagedResultDto{OrganizationUserGetPagedOutput}"/></returns>
        Task<PagedResultDto<OrganizationUserGetPagedOutput>> GetPagedForUser(OrganizationUserGetPagedInput input);

        /// <summary>
        /// The AddUser2OrganizationAsync
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationUserInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task AddUser2OrganizationAsync(OrganizationUserInput input);

        /// <summary>
        /// The RemoveUser2OrganizationAsync
        /// </summary>
        /// <param name="input">The input<see cref="OrganizationUserInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task RemoveUser2OrganizationAsync(OrganizationUserInput input);

    }
}
