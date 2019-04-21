namespace AbpLearning.Core.Configuration
{
    using Abp.Configuration;
    using Abp.Localization;

    public abstract class AppSettingProvider : SettingProvider
    {
        protected static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpLearningCoreConfig.LOCALIZATION_SOURCE_NAME);
        }
    }
}
