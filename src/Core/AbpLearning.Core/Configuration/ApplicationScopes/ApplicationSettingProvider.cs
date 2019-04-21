namespace AbpLearning.Core.Configuration.ApplicationScopes
{
    using System.Collections.Generic;
    using System.Linq;
    using Abp.Configuration;
    using ThirdPartyAuthorizationConfiguration;
    using static ApplicationSettingNames.ThirdPartyAuth;

    public class ApplicationSettingProvider : AppSettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return GetSettings();
        }

        public static IEnumerable<SettingDefinition> GetSettings()
        {
            return GetThirdPartyAuthSettings().Union(GetGitHubAuthSettings());
        }

        private static IEnumerable<SettingDefinition> GetThirdPartyAuthSettings()
        {
            var group = new SettingDefinitionGroup(SETTING_NAME, L(SETTING_NAME + ".Authorization.DisplayName"));
            return new[]
            {
                new SettingDefinition(IS_ENABLED_THIRD_AUTH,ThirdPartyAuthConfig.IS_ENABLED_THIRD_AUTH.ToString(),isVisibleToClients:true,group:group),
            };
        }

        private static IEnumerable<SettingDefinition> GetGitHubAuthSettings()
        {
            var group = new SettingDefinitionGroup(GitHubAuth.SETTING_NAME, L(GitHubAuth.SETTING_NAME + ".Authorization.Type.DisplayName"));
            return new[]
            {
                new SettingDefinition(
                    name:GitHubAuth.IS_ENABLED,
                    defaultValue: GitHubAuthConfig.IS_ENABLED.ToString(),
                    displayName:L(GitHubAuth.IS_ENABLED+".DisplayName"),
                    group:group,
                    description:L(GitHubAuth.IS_ENABLED+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:GitHubAuth.AUTHORIZATION_TYPE,
                    defaultValue:GitHubAuthConfig.AUTHORIZATION_TYPE,
                    displayName:L(GitHubAuth.AUTHORIZATION_TYPE+".DisplayName"),
                    group:group,
                    description:L(GitHubAuth.AUTHORIZATION_TYPE+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:GitHubAuth.CLIENT_ID,
                    defaultValue:GitHubAuthConfig.CLIENT_ID,
                    displayName:L(GitHubAuth.CLIENT_ID+".DisplayName"),
                    group:group,
                    description:L(GitHubAuth.CLIENT_ID+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:GitHubAuth.CLIENT_SECRET,
                    defaultValue:GitHubAuthConfig.CLIENT_SECRET,
                    displayName:L(GitHubAuth.CLIENT_SECRET+".DisplayName"),
                    group:group,
                    description:L(GitHubAuth.CLIENT_SECRET+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:GitHubAuth.AUTHORIZATION_NENDPOINT,
                    defaultValue:GitHubAuthConfig.AUTHORIZATIO_NENDPOINT,
                    displayName:L(GitHubAuth.AUTHORIZATION_NENDPOINT+".DisplayName"),
                    group:group,
                    description:L(GitHubAuth.AUTHORIZATION_NENDPOINT+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:GitHubAuth.TOKEN_ENDPOINT,
                    defaultValue:GitHubAuthConfig.TOKEN_ENDPOINT,
                    displayName:L(GitHubAuth.TOKEN_ENDPOINT+".DisplayName"),
                    group:group,
                    description:L(GitHubAuth.TOKEN_ENDPOINT+".Description"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:GitHubAuth.USERINFO_ENDPOINT,
                    defaultValue:GitHubAuthConfig.USERINFO_ENDPOINT,
                    displayName:L(GitHubAuth.USERINFO_ENDPOINT+".DisplayName"),
                    group:group,
                    description:L(GitHubAuth.USERINFO_ENDPOINT+".Description"),
                    isVisibleToClients:true
                    ),
            };
        }
    }
}
