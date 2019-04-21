namespace AbpLearning.Core.Configuration.ApplicationScopes
{
    public static class ApplicationSettingNames
    {
        public const string SETTING_NAME = "Application";

        /// <summary>
        /// 第三方授权
        /// </summary>
        public static class ThirdPartyAuth
        {
            public const string SETTING_NAME = ApplicationSettingNames.SETTING_NAME + ".ThirdPartyAuth";

            public const string IS_ENABLED_THIRD_AUTH = SETTING_NAME + ".IsEnabled";

            /// <summary>
            /// GitHub 授权
            /// </summary>
            public static class GitHubAuth
            {
                public const string SETTING_NAME = ThirdPartyAuth.SETTING_NAME + ".GitHub";
                /// <summary>
                /// 是否启用
                /// </summary>
                public const string IS_ENABLED = SETTING_NAME + ".IsEnabled";

                /// <summary>
                /// 授权类型
                /// </summary>
                public const string AUTHORIZATION_TYPE = SETTING_NAME + ".AuthorizationType";

                /// <summary>
                /// Client Id
                /// </summary>
                public const string CLIENT_ID = SETTING_NAME + ".ClientId";

                /// <summary>
                /// Client Secret
                /// </summary>
                public const string CLIENT_SECRET = SETTING_NAME + ".ClientSecret";

                /// <summary>
                /// 授权地址
                /// </summary>
                public const string AUTHORIZATION_NENDPOINT = SETTING_NAME + ".AuthorizationEndpoint";

                /// <summary>
                /// 获取Access Token
                /// </summary>
                public const string TOKEN_ENDPOINT = SETTING_NAME + ".TokenEndpoint";

                /// <summary>
                /// 获取用户信息地址
                /// </summary>
                public const string USERINFO_ENDPOINT = SETTING_NAME + ".UserinfoEndpoint";
            }
        }
    }
}
