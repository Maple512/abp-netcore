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
            var group = new SettingDefinitionGroup(ThirdPartyAuth.SETTING_NAME, L(ThirdPartyAuth.GITHUB_AUTH + ".Authorization.Type.dn"));

            return new[]
            {
                new SettingDefinition(
                    name:nameof(GithubAuthConfig.GithubAuthIsEnabled),
                    defaultValue: GithubAuthConfig.GithubAuthIsEnabled.ToString(),
                    displayName:L(nameof(GithubAuthConfig.GithubAuthIsEnabled)+".dn"),
                    group:group,
                    description:L(nameof(GithubAuthConfig.GithubAuthIsEnabled)+".d"),
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:nameof(GithubAuthConfig.GithubAuthClientId),
                    defaultValue:GithubAuthConfig.GithubAuthClientId,
                    displayName:L(nameof(GithubAuthConfig.GithubAuthClientId)+".dn"),
                    group:group,
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:nameof(GithubAuthConfig.GithubAuthClientSecret),
                    defaultValue:GithubAuthConfig.GithubAuthClientSecret,
                    displayName:L(nameof(GithubAuthConfig.GithubAuthClientSecret)+".dn"),
                    group:group,
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:nameof(GithubAuthConfig.GithubAuthAuthorizeUrl),
                    defaultValue:GithubAuthConfig.GithubAuthAuthorizeUrl,
                    displayName:L(nameof(GithubAuthConfig.GithubAuthAuthorizeUrl)+".dn"),
                    group:group,
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:nameof(GithubAuthConfig.GithubAuthAccessTokenUrl),
                    defaultValue:GithubAuthConfig.GithubAuthAccessTokenUrl,
                    displayName:L(nameof(GithubAuthConfig.GithubAuthAccessTokenUrl)+".dn"),
                    group:group,
                    isVisibleToClients:true
                    ),
                new SettingDefinition(
                    name:nameof(GithubAuthConfig.GithubAuthUserinfoUrl),
                    defaultValue:GithubAuthConfig.GithubAuthUserinfoUrl,
                    displayName:L(nameof(GithubAuthConfig.GithubAuthUserinfoUrl)+".dn"),
                    group:group,
                    isVisibleToClients:true
                    ),
            };
        }
    }
}
