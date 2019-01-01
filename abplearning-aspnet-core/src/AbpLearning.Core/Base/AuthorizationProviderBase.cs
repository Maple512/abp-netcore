namespace AbpLearning.Core.Base
{
    using Abp.Authorization;
    using Abp.Configuration.Startup;
    using Abp.Localization;

    public abstract class AuthorizationProviderBase : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        protected AuthorizationProviderBase(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        protected AuthorizationProviderBase(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        internal static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpLearningConsts.LocalizationSourceName);
        }
    }
}
