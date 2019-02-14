namespace AbpLearning.Application.AuditLogs
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Auditing;
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using AbpLearning.Application.AuditLogs.Model;
    using AbpLearning.Core;
    using AbpLearning.Core.Authorization.Users;
    using Microsoft.EntityFrameworkCore;
    using AbpLearning.Common.Extensions;

    [DisableAuditing]
    [AbpAuthorize(AbpLearningPermissions.AuditLog)]
    public class AuditLogAppService : AbpLearningAppServiceBase, IAuditLogAppService
    {
        private readonly IRepository<AuditLog, long> _auditLog;
        private readonly IRepository<User, long> _user;

        public AuditLogAppService(IRepository<AuditLog, long> auditLog, IRepository<User, long> user)
        {
            _auditLog = auditLog;
            _user = user;
        }

        public async Task<PagedResultDto<AuditLogPagedModel>> GetPaged(AuditLogPagedFilteringModel model)
        {
            var query = CreateAuditLogAndUserQuery(model);

            var sql = query.AsNoTracking()
                .OrderBy(model.Sorting)
                .PageBy(model).ToSql();

            var count = await query.CountAsync();

            var result = await query.AsNoTracking()
                .OrderBy(model.Sorting)
                .PageBy(model)
                .ToListAsync();

            var auditLogs = ConvertToPaged(result);

            return new PagedResultDto<AuditLogPagedModel>(count, auditLogs);
        }

        private IQueryable<AuditLogAndUser> CreateAuditLogAndUserQuery(AuditLogPagedFilteringModel model)
        {
            IQueryable<AuditLogAndUser> query;

            query = from auditLog in _auditLog.GetAll().AsNoTracking()
                    join user in _user.GetAll().AsNoTracking() on auditLog.UserId equals user.Id
                    into userJoin
                    from joinedUser in userJoin.DefaultIfEmpty()
                    select new AuditLogAndUser { AuditLogInfo = auditLog, UserInfo = joinedUser };

            if (model.StartDate.HasValue)
            {
                model.StartDate = model.StartDate.Value.Date;
            }

            if (model.EndDate.HasValue)
            {
                model.EndDate = model.EndDate.Value.Date.AddDays(1).AddMilliseconds(-1);
            }

            query = query
                .WhereIf(model.StartDate.HasValue, item => item.AuditLogInfo.ExecutionTime >= model.StartDate)
                .WhereIf(model.EndDate.HasValue, item => item.AuditLogInfo.ExecutionTime <= model.EndDate)
                .WhereIf(!model.UserName.IsNullOrWhiteSpace(), item => item.UserInfo.UserName.Contains(model.UserName))
                .WhereIf(!model.ServiceName.IsNullOrWhiteSpace(),
                    item => item.AuditLogInfo.ServiceName.Contains(model.ServiceName))
                .WhereIf(!model.MethodName.IsNullOrWhiteSpace(),
                    item => item.AuditLogInfo.MethodName.Contains(model.MethodName))
                .WhereIf(!model.BrowserInfo.IsNullOrWhiteSpace(),
                    item => item.AuditLogInfo.BrowserInfo.Contains(model.BrowserInfo))
                .WhereIf(model.MinExecutionDuration.HasValue && model.MinExecutionDuration > 0,
                    item => item.AuditLogInfo.ExecutionDuration >= model.MinExecutionDuration.Value)
                .WhereIf(model.MaxExecutionDuration.HasValue && model.MaxExecutionDuration < int.MaxValue,
                    item => item.AuditLogInfo.ExecutionDuration <= model.MaxExecutionDuration.Value)
                .WhereIf(model.HasException == true,
                    item => item.AuditLogInfo.Exception != null && item.AuditLogInfo.Exception != "")
                .WhereIf(model.HasException == false,
                    item => item.AuditLogInfo.Exception == null || item.AuditLogInfo.Exception == "");

            return query;
        }

        private List<AuditLogPagedModel> ConvertToPaged(List<AuditLogAndUser> results)
        {
            return results.Select(
                result =>
                {
                    var auditLogs = ObjectMapper.Map<AuditLogPagedModel>(result.AuditLogInfo);
                    auditLogs.UserName = result.UserInfo?.UserName;
                    auditLogs.ServiceName = GetServiceName(auditLogs.ServiceName);
                    return auditLogs;
                }).ToList();
        }

        private string GetServiceName(string serviceName)
        {
            if (serviceName.IsNullOrWhiteSpace()) return null;

            var list = serviceName.Split(".");

            return list[list.Count() - 1];
        }
    }
}
