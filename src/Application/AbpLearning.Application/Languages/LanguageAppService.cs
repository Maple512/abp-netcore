namespace AbpLearning.Application.Languages
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Collections.Extensions;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using Abp.Localization;
    using AbpLearning.Application.Languages.Dto;
    using AbpLearning.Common.Helper;
    using AbpLearning.Core;

    [AbpAuthorize(AbpLearningPermissions.Language)]
    public class LanguageAppService : AbpLearningAppServiceBase, ILanguageAppService
    {
        private readonly IApplicationLanguageManager _languageManager;

        private readonly IApplicationLanguageTextManager _languageTextManager;

        public LanguageAppService(
            IApplicationLanguageManager languageManager,
            IApplicationLanguageTextManager languageTextManager)
        {
            _languageManager = languageManager;
            _languageTextManager = languageTextManager;
        }

        public async Task<LanguageGetPagedOutput> GetLanguagePagedAsync(LanguageGetPagedInput input)
        {
            var languages = (await _languageManager.GetLanguagesAsync(AbpSession.TenantId)).OrderBy(l => l.DisplayName);
            var defaultLanguage = await _languageManager.GetDefaultLanguageOrNullAsync(AbpSession.TenantId);

            return new LanguageGetPagedOutput
            {
                DefaultLanguageName = defaultLanguage?.Name,
                Items = ObjectMapper.Map<List<LanguagePagedDto>>(languages)
            };
        }

        public async Task<ListResultDto<NameValueDto>> GetLanguageOptionsAsync()
        {
            var languages = (await _languageManager.GetLanguagesAsync(AbpSession.TenantId))
                .OrderBy(l => l.DisplayName)
                .Select(l => new NameValueDto { Name = l.DisplayName, Value = l.DisplayName });

            return new ListResultDto<NameValueDto>()
            {
                Items = ObjectMapper.Map<List<NameValueDto>>(languages)
            };
        }

        public PagedResultDto<LanguageTextGetPagedOutput> GetLanguageTextPaged(LanguageTextGetPagedInput input)
        {
            var sources = LocalizationManager.GetSource(input.SourceName);
            var culture = CultureInfo.GetCultureInfo(input.LanguageName);
            var contrastCulture = CultureInfo.GetCultureInfo(input.ContrastLanguageName);

            var languageTexts = sources.GetAllStrings()
                .Select(l => new LanguageTextGetPagedOutput
                {
                    Key = l.Name,
                    Value = _languageTextManager.GetStringOrNull(tenantId: AbpSession.TenantId, sourceName: sources.Name, culture: culture, key: l.Name),
                    ContrastValue = _languageTextManager.GetStringOrNull(tenantId: AbpSession.TenantId, sourceName: sources.Name, culture: contrastCulture, key: l.Name, false),
                })
                .AsQueryable();

            if (input.TargetValueFilter == LanguageTextGetPagedInput.TargetValueFilterEnum.Empty)
            {
                languageTexts = languageTexts.Where(l => l.Value.IsNullOrEmpty());
            }

            if (!input.FilterText.IsNullOrEmpty())
            {
                languageTexts = languageTexts.Where(l =>
                    l.Key != null && l.Key.IndexOf(input.FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                    l.Value != null && l.Value.IndexOf(input.FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                    l.ContrastValue != null && l.ContrastValue.IndexOf(input.FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0
                );
            }

            var totalCount = languageTexts.Count();

            var paged = languageTexts.OrderBy(input.Sorting)
                .PageBy(input)
                .ToList();

            return new PagedResultDto<LanguageTextGetPagedOutput>(totalCount, paged);
        }

        public async Task<ListResultDto<NameValueDto>> GetLocalizationSourceOptionsAsync()
        {
            var sources = LocalizationManager.GetAllSources()
               .OrderBy(s => s.Name)
               .Select(l => new NameValueDto { Name = l.Name, Value = l.Name });

            return new ListResultDto<NameValueDto>()
            {
                Items = ObjectMapper.Map<List<NameValueDto>>(sources)
            };
        }

        public async Task UpdateLanguageTextAsync(LanguageTextUpdateInput input)
        {
            var culture = CultureHelper.GetCultureInfo(input.LanguageName);

            var source = LocalizationManager.GetSource(input.SourceName);

            await _languageTextManager.UpdateStringAsync(AbpSession.TenantId, source.Name, culture, input.Key, input.Value);
        }
    }
}
