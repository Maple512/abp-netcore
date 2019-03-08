namespace AbpLearning.Application.Users
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using AbpLearning.Application.Authorization.Roles.Dto;
    using Dto;

    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleGetViewOutput>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
