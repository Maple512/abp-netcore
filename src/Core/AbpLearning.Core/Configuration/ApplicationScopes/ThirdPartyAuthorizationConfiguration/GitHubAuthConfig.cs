namespace AbpLearning.Core.Configuration.ApplicationScopes.ThirdPartyAuthorizationConfiguration
{
    public class GitHubAuthConfig
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public const bool IS_ENABLED = true;

        /// <summary>
        /// 授权类型
        /// </summary>
        public const string AUTHORIZATION_TYPE = "Github";

        /// <summary>
        /// Client Id
        /// </summary>
        public const string CLIENT_ID = "9381792e7265342f63e8";

        /// <summary>
        /// Client Secret
        /// </summary>
        public const string CLIENT_SECRET = "9098720cabe90cdb78d83876214c532767728a64";

        /// <summary>
        /// 授权地址
        /// </summary>
        public const string AUTHORIZATIO_NENDPOINT = "https://github.com/login/oauth/authorize";

        /// <summary>
        /// 获取Access Token
        /// </summary>
        public const string TOKEN_ENDPOINT = "https://github.com/login/oauth/access_token";

        /// <summary>
        /// 获取用户信息地址
        /// </summary>
        public const string USERINFO_ENDPOINT = "https://api.github.com/user";
    }
}
