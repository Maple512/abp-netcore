namespace AbpLearning.Core.Configuration.ApplicationScopes
{
    using Abp.Configuration;
    using System.Collections.Generic;
    using System.Linq;
    using ThirdPartyAuthorizationConfiguration;
    using static ApplicationSettingNames;

    public class ApplicationSettingProvider : AppSettingProvider
    {
        public const SettingScopes Scope = SettingScopes.Application;

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return GetGitHubAuthSettings().Select(m =>
            {
                m.Scopes = Scope;
                return m;
            });
        }

        /// <summary>
        /// GitHub Settings
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<SettingDefinition> GetGitHubAuthSettings()
        {
            var group = new SettingDefinitionGroup(ThirdPartyAuth.SETTING_NAME, L(ThirdPartyAuth.GITHUB_AUTH + ".Authorization.Type.DisplayName"));

            return new[]
            {
                new SettingDefinition(
                    name:nameof(GitHubAuthConfig.GITHUB_AUTH_IS_ENABLED),
                    defaultValue: GitHubAuthConfig.GITHUB_AUTH_IS_ENABLED.ToString(),
                    displayName:L(nameof(GitHubAuthConfig.GITHUB_AUTH_IS_ENABLED)+".DisplayName"),
                    group:group,
                    description:L(nameof(GitHubAuthConfig.GITHUB_AUTH_IS_ENABLED)+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:nameof(GitHubAuthConfig.GITHUB_AUTH_AUTHORIZATION_TYPE),
                    defaultValue:GitHubAuthConfig.GITHUB_AUTH_AUTHORIZATION_TYPE,
                    displayName:L(nameof(GitHubAuthConfig.GITHUB_AUTH_AUTHORIZATION_TYPE)+".DisplayName"),
                    group:group,
                    description:L(nameof(GitHubAuthConfig.GITHUB_AUTH_AUTHORIZATION_TYPE)+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:nameof(GitHubAuthConfig.GITHUB_AUTH_CLIENT_ID),
                    defaultValue:GitHubAuthConfig.GITHUB_AUTH_CLIENT_ID,
                    displayName:L(nameof(GitHubAuthConfig.GITHUB_AUTH_CLIENT_ID)+".DisplayName"),
                    group:group,
                    description:L(nameof(GitHubAuthConfig.GITHUB_AUTH_CLIENT_ID)+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:nameof(GitHubAuthConfig.GITHUB_AUTH_CLIENT_SECRET),
                    defaultValue:GitHubAuthConfig.GITHUB_AUTH_CLIENT_SECRET,
                    displayName:L(nameof(GitHubAuthConfig.GITHUB_AUTH_CLIENT_SECRET)+".DisplayName"),
                    group:group,
                    description:L(nameof(GitHubAuthConfig.GITHUB_AUTH_CLIENT_SECRET)+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:nameof(GitHubAuthConfig.GITHUB_AUTH_AUTHORIZE_URL),
                    defaultValue:GitHubAuthConfig.GITHUB_AUTH_AUTHORIZE_URL,
                    displayName:L(nameof(GitHubAuthConfig.GITHUB_AUTH_AUTHORIZE_URL)+".DisplayName"),
                    group:group,
                    description:L(nameof(GitHubAuthConfig.GITHUB_AUTH_AUTHORIZE_URL)+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:nameof(GitHubAuthConfig.GITHUB_AUTH_ACCESS_TOKEN_URL),
                    defaultValue:GitHubAuthConfig.GITHUB_AUTH_ACCESS_TOKEN_URL,
                    displayName:L(nameof(GitHubAuthConfig.GITHUB_AUTH_ACCESS_TOKEN_URL)+".DisplayName"),
                    group:group,
                    description:L(nameof(GitHubAuthConfig.GITHUB_AUTH_ACCESS_TOKEN_URL)+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:nameof(GitHubAuthConfig.GITHUB_AUTH_USERINFO_URL),
                    defaultValue:GitHubAuthConfig.GITHUB_AUTH_USERINFO_URL,
                    displayName:L(nameof(GitHubAuthConfig.GITHUB_AUTH_USERINFO_URL)+".DisplayName"),
                    group:group,
                    description:L(nameof(GitHubAuthConfig.GITHUB_AUTH_USERINFO_URL)+".Description"),
                    isVisibleToClients:true
                    ),
            };
        }
    }
}
