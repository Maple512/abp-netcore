namespace AbpLearning.Application.MultiTenancy
{
    using AbpLearning.Application.Base;
    using AbpLearning.MultiTenancy.Dto;
    using Dto;

    public interface ITenantAppService : ICrudAsyncAppService<int, TenantGetViewOutput, TenantGetPagedOutput, PagedFilteringModelBase, TenantGetUpdateOutput, TenantCreateInput, TenantUpdateInput>
    {
    }
}
