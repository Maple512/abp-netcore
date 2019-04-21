namespace AbpLearning.Application.Languages
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using AbpLearning.Application.Languages.Dto;

    public interface ILanguageAppService : IApplicationService
    {
        Task<LanguageGetPagedOutput> GetLanguagePagedAsync(LanguageGetPagedInput input);

        PagedResultDto<LanguageTextGetPagedOutput> GetLanguageTextPaged(LanguageTextGetPagedInput input);

        Task<ListResultDto<NameValueDto>> GetLanguageOptionsAsync();

        Task<ListResultDto<NameValueDto>> GetLocalizationSourceOptionsAsync();

        Task UpdateLanguageTextAsync(LanguageTextUpdateInput input);
    }
}
