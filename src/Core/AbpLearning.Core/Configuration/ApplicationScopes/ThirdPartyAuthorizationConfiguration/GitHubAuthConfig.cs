namespace AbpLearning.Core.Configuration.ApplicationScopes.ThirdPartyAuthorizationConfiguration
{
    public class GithubAuthConfig
    {
        /// <summary>
        /// GitHub授权是否启用
        /// </summary>
        public const bool GithubAuthIsEnabled = true;

        /// <summary>
        /// GitHub授权Client Id
        /// </summary>
        public const string GithubAuthClientId = "9381792e7265342f63e8";

        /// <summary>
        /// GitHub授权Client Secret
        /// </summary>
        public const string GithubAuthClientSecret = "9098720cabe90cdb78d83876214c532767728a64";

        /// <summary>
        /// GitHub授权地址
        /// </summary>
        public const string GithubAuthAuthorizeUrl = "https://github.com/login/oauth/authorize";

        /// <summary>
        /// GitHub授权获取Access Token
        /// </summary>
        public const string GithubAuthAccessTokenUrl = "https://github.com/login/oauth/access_token";

        /// <summary>
        /// GitHub授权获取用户信息地址
        /// </summary>
        public const string GithubAuthUserinfoUrl = "https://api.github.com/user";
    }
}
