namespace AbpLearning.Application.Authorization.Roles
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Base;
    using Dto;

    /// <summary>
    /// this interface is Role AppService
    /// </summary>
    public interface IRoleAppService : ICrudAsyncAppService<int, RoleGetViewOutput, RoleGetPagedOutput, RoleGetPagedInput, RoleGetUpdateOutput, RoleCreateInput, RoleUpdateDto>, IApplicationService
    {
        /// <summary>
        /// Get All For View
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultDto<RoleGetViewOutput>> GetAllForViewAsync(RoleGetViewInput input);

        /// <summary>
        /// async check role name for repeat
        /// </summary>
        /// <param name="expectedRoleId"></param>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        Task<bool> CheckDuplicateRoleNameAsync(int? expectedRoleId, string name, string displayName);
    }
}
