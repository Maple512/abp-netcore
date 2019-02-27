using System.Threading.Tasks;
using AbpLearning.Application.Configuration.Dto;

namespace AbpLearning.Application.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
