namespace AbpLearning.Core.Configuration.ApplicationScopes.ThirdPartyAuthorizationConfiguration
{
    public class GitHubAuthConfig
    {
        /// <summary>
        /// GitHub授权是否启用
        /// </summary>
        public const bool GITHUB_AUTH_IS_ENABLED = true;

        /// <summary>
        /// GitHub授权类型
        /// </summary>
        public const string GITHUB_AUTH_AUTHORIZATION_TYPE = "Github";

        /// <summary>
        /// GitHub授权Client Id
        /// </summary>
        public const string GITHUB_AUTH_CLIENT_ID = "9381792e7265342f63e8";

        /// <summary>
        /// GitHub授权Client Secret
        /// </summary>
        public const string GITHUB_AUTH_CLIENT_SECRET = "9098720cabe90cdb78d83876214c532767728a64";

        /// <summary>
        /// GitHub授权地址
        /// </summary>
        public const string GITHUB_AUTH_AUTHORIZE_URL = "https://github.com/login/oauth/authorize";

        /// <summary>
        /// GitHub授权获取Access Token
        /// </summary>
        public const string GITHUB_AUTH_ACCESS_TOKEN_URL = "https://github.com/login/oauth/access_token";

        /// <summary>
        /// GitHub授权获取用户信息地址
        /// </summary>
        public const string GITHUB_AUTH_USERINFO_URL = "https://api.github.com/user";
    }
}
