namespace AbpLearning.Application.Authorization.Roles
{
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using AbpLearning.Application.Authorization.Roles.Dto;
    using AbpLearning.Application.Base;
    using AbpLearning.Core;
    using AbpLearning.Core.Authorization.Roles;

    [AbpAuthorize(AbpLearningPermissions.Role)]
    public class RoleAppService : CrudAsyncAppService<Role, int, RoleGetViewOutput, RoleGetPagedOutput, RoleGetPagedInput, RoleUpdateDto, RoleCreateInput, RoleUpdateDto>
    {
        private readonly RoleManager _roleManager;

        private readonly IPermissionManager _permissionManager;

        public RoleAppService(RoleManager roleManager, IPermissionManager permissionManager, IRepository<Role, int> repository) : base(repository)
        {
            _roleManager = roleManager;
            _permissionManager = permissionManager;
        }

        protected override string NodePermissionName => AbpLearningPermissions.Role;


    }
}
