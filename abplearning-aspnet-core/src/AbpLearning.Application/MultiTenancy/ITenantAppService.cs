using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpLearning.MultiTenancy.Dto;

namespace AbpLearning.Application.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
