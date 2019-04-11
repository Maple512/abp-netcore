namespace AbpLearning.Application.AuditLogs
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using AbpLearning.Application.AuditLogs.Model;

    public interface IAuditLogAppService: IApplicationService
    {
        Task<PagedResultDto<AuditLogPagedModel>> GetPaged(AuditLogPagedFilteringModel model);
    }
}
