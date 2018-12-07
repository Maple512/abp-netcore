using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AbpLearning.Core.Localization
{
    public static class AbpLearningLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AbpLearningConsts.LocalizationSourceName_Core,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AbpLearningLocalizationConfigurer).GetAssembly(),
                        "AbpLearning.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
