namespace AbpLearning.Application.Configurations.Settings
{
    using Abp.Configuration;
    using AbpLearning.Core.Configuration.ApplicationScopes.ThirdPartyAuthorizationConfiguration;
    using Dto;
    using System;
    using System.Threading.Tasks;

    public class SettingsAppService : AbpLearningAppServiceBase, ISettingsAppService
    {
        private readonly SettingManager _settingManager;

        public SettingsAppService(SettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        #region All Scopes

        public Task<AllScopesSettingsDto> GetAllScopesSettingsAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Application Scopes

        public async Task<ApplicationSettingsDto> GetApplicationSettingsAsync()
        {
            return new ApplicationSettingsDto()
            {
                GithubAuthSetting = await GetGithubAuthOutputAsync(),
            };
        }

        private async Task<GithubAuthSettingsDto> GetGithubAuthOutputAsync()
        {
            return new GithubAuthSettingsDto
            {
                AccessTokenUrl = await _settingManager.GetSettingValueForApplicationAsync(nameof(GithubAuthConfig.GithubAuthAccessTokenUrl)),
                AuthorizeUrl = await _settingManager.GetSettingValueForApplicationAsync(nameof(GithubAuthConfig.GithubAuthAuthorizeUrl)),
                ClientId = await _settingManager.GetSettingValueForApplicationAsync(nameof(GithubAuthConfig.GithubAuthClientId)),
                ClientSecret = await _settingManager.GetSettingValueForApplicationAsync(nameof(GithubAuthConfig.GithubAuthClientSecret)),
                UserinfoUrl = await _settingManager.GetSettingValueForApplicationAsync(nameof(GithubAuthConfig.GithubAuthUserinfoUrl)),
                IsEnabled = await _settingManager.GetSettingValueForApplicationAsync<bool>(nameof(GithubAuthConfig.GithubAuthIsEnabled)),
            };
        }

        #endregion

        #region Tenant Scopes

        public Task<TenantSettingsDto> GetTenantSettingsAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region User Scopes

        public Task<UserSettingsDto> GetUserSettingsAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
