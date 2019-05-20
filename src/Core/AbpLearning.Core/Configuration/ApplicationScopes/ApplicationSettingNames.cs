namespace AbpLearning.Core.Configuration.ApplicationScopes
{
    public static class ApplicationSettingNames
    {
        public const string SETTING_NAME = "Application_Setting";

        /// <summary>
        /// 第三方授权
        /// </summary>
        public static class ThirdPartyAuth
        {
            public const string SETTING_NAME = ApplicationSettingNames.SETTING_NAME + "_ThirdPartyAuth";

            /// <summary>
            /// GitHub
            /// </summary>
            public const string GITHUB_AUTH = SETTING_NAME + "_GitHub";
        }
    }
}
