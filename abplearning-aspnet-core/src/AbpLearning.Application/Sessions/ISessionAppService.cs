using System.Threading.Tasks;
using Abp.Application.Services;
using AbpLearning.Application.Sessions.Dto;

namespace AbpLearning.Application.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
