namespace AbpLearning.Application.Users
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Dto;
    using Roles.Model;

    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleViewModel>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
