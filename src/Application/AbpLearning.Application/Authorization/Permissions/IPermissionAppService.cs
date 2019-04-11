namespace AbpLearning.Application.Authorization.Permissions
{
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using AbpLearning.Application.Authorization.Permissions.Dto;

    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<PermissionGetViewOutput> GetViewAll(PermissionGetViewInput input);
    }
}
