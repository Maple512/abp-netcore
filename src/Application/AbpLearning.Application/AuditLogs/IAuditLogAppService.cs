namespace AbpLearning.Application.AuditLogs
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using AbpLearning.Application.AuditLogs.Dto;

    public interface IAuditLogAppService: IApplicationService
    {
        Task<PagedResultDto<AuditLogGetPagedOutput>> GetPaged(AuditLogGetPagedInput model);
    }
}
