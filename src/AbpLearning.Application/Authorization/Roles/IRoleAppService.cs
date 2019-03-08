namespace AbpLearning.Application.Authorization.Roles
{
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using AbpLearning.Application.Authorization.Roles.Dto;
    using AbpLearning.Application.Base;

    public interface IRoleAppService : ICrudAsyncAppService<int, RoleGetViewOutput, RoleGetPagedOutput, RoleGetPagedInput, RoleUpdateDto, RoleCreateInput, RoleUpdateDto>
    {
        Task<ListResultDto<>>
    }
}
