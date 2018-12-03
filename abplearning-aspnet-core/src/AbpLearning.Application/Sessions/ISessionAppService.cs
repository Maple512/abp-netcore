using System.Threading.Tasks;
using Abp.Application.Services;
using AbpLearning.Sessions.Dto;

namespace AbpLearning.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
