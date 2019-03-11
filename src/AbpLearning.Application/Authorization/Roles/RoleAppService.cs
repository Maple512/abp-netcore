namespace AbpLearning.Application.Authorization.Roles
{
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Base;
    using Core;
    using Core.Authorization.Roles;
    using Dto;

    [AbpAuthorize(AbpLearningPermissions.Role)]
    public class RoleAppService : CrudAsyncAppService<Role, int, RoleGetViewOutput, RoleGetPagedOutput, RoleGetPagedInput, RoleGetUpdateOutput, RoleCreateInput, RoleUpdateDto>, IRoleAppService
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
        public async Task<bool> CheckDuplicateRoleNameAsync(int? expectedRoleId, string name, string displayName)
        {
            return (await _roleManager.CheckDuplicateRoleNameAsync(null, name, displayName)).Succeeded;
        }

        /// <summary>
        /// async get all for role view model
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<ListResultDto<RoleGetViewOutput>> GetAllForViewAsync(RoleGetViewInput input)
        {
            throw new System.NotImplementedException();
        }
    }
}
