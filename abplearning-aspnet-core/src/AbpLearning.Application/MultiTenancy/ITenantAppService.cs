using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpLearning.MultiTenancy.Dto;

namespace AbpLearning.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
