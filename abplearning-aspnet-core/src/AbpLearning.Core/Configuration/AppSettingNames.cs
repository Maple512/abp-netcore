namespace AbpLearning.Core.Configuration
{
    using Abp.Configuration;

    /// <summary>
    /// App Setting Names
    /// <see cref="AppSettingProvider"/> for setting definitions.
    /// <see cref="SettingScopes"/> for setting scopes
    /// </summary>
    public static class AppSettingNames
    {
        public const string UiTheme = "App.UiTheme";

        /// <summary>
        /// Application Settings
        /// </summary>
        public static class Application
        {
            /// <summary>
            /// 是否允许注册租户
            /// </summary>
            public const string IsTenantRegister = "IsTenantRegister";

            /// <summary>
            /// 是否允许新租户默认激活
            /// </summary>
            public const string IsDefaultActivationForNewTenant = "IsDefaultActivationForNewTenant";
        }

        public static class Tenant
        {

        }

        public static class User
        {

        }
        
        public static class All
        {

        }

    }
}
