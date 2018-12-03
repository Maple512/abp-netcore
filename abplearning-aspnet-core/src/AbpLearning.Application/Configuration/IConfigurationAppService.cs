using System.Threading.Tasks;
using AbpLearning.Configuration.Dto;

namespace AbpLearning.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
