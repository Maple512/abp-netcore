namespace AbpLearning.Application.MultiTenancy
{
    using Abp.Application.Services;
    using AbpLearning.Application.Base;
    using AbpLearning.MultiTenancy.Dto;
    using Dto;

    public interface ITenantAppService : ICrudAsyncAppService<int, TenantGetViewOutput, TenantGetPagedOutput, TenantGetPagedInput, TenantGetUpdateOutput, TenantCreateInput, TenantUpdateInput>, IApplicationService
    {
    }
}
