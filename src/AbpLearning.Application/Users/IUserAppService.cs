namespace AbpLearning.Application.Users
{
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using AbpLearning.Application.Authorization.Roles.Dto;
    using AbpLearning.Application.Base;
    using Dto;

    public interface IUserAppService : ICrudAsyncAppService<long, UserGetViewOutput, UserGetPagedOutput, UserGetPagedInput, UserGetUpdateOutput, UserCreateInput, UserUpdateInput>
    {
        Task<ListResultDto<RoleGetViewOutput>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
