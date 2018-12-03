using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AbpLearning.Configuration.Dto;

namespace AbpLearning.Configuration
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
