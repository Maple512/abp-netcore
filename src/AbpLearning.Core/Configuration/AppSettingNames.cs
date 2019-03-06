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
            
        }

        /// <summary>
        /// Tenant Settings
        /// </summary>
        public static class Tenant
        {
            /// <summary>
            /// 是否允许注册租户
            /// </summary>
            public const string IsTenantRegister = "IsTenantRegister";

            /// <summary>
            /// 是否允许新租户默认激活
            /// </summary>
            public const string IsDefaultActivationForNewTenant = "IsDefaultActivationForNewTenant";

            /// <summary>
            /// 注册时的验证码类型
            /// <see cref=""/>
            /// </summary>
            public const string VerificationCodeTypeAtRegistration = "VerificationCodeTypeAtRegistration";
        }

        /// <summary>
        /// User Settings
        /// </summary>
        public static class User
        {

        }

        /// <summary>
        /// All Settings
        /// </summary>
        public static class All
        {

        }

    }
}
