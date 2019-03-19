namespace AbpLearning.Application.Authorization.Permissions
{
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using AbpLearning.Application.Authorization.Permissions.Dto;

    public class PermissionAppService : AbpLearningAppServiceBase, IPermissionAppService
    {
        private readonly IPermissionManager _permissionManager;

        public PermissionAppService(IPermissionManager permissionManager)
        {
            _permissionManager = permissionManager;
        }

        public ListResultDto<PermissionGetViewOutput> GetViewAll(PermissionGetViewInput input)
        {
            var permissions = _permissionManager.GetAllPermissions();

            return ObjectMapper.Map<ListResultDto<PermissionGetViewOutput>>(permissions);
        }
    }
}
