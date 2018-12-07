using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AbpLearning.Application.Configuration.Dto;
using AbpLearning.Core.Configuration;

namespace AbpLearning.Application.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AbpLearningAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
