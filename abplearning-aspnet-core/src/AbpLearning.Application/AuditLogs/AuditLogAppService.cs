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
            var query = CreateAuditLogQuery(model);

            var count = await query.CountAsync();

            var test = query.AsNoTracking()
                .OrderBy(model.Sorting)
                .PageBy(model);

            var result = await query.AsNoTracking()
                .OrderBy(model.Sorting)
                .PageBy(model)
                .ToListAsync();

            return new PagedResultDto<AuditLogPagedModel>(count, result);
        }

        /// <summary>
        /// 构建审计日志查询语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private IQueryable<AuditLogPagedModel> CreateAuditLogQuery(AuditLogPagedFilteringModel model)
        {
            IQueryable<AuditLogPagedModel> query;

            query = from auditLog in _auditLog.GetAll().AsNoTracking()
                    join user in _user.GetAll().AsNoTracking() on auditLog.UserId equals user.Id
                    into userJoin
                    from joinedUser in userJoin.DefaultIfEmpty()
                    select new AuditLogPagedModel
                    {
                        BrowserInfo = auditLog.BrowserInfo,
                        ClientIPAddress = auditLog.ClientIpAddress,
                        ClientName = auditLog.ClientName,
                        CustomData = auditLog.CustomData,
                        Exception = auditLog.Exception,
                        ExecutionDuration = auditLog.ExecutionDuration,
                        ExecutionTime = auditLog.ExecutionTime,
                        MethodName = auditLog.MethodName,
                        Parameters = auditLog.Parameters,
                        ServiceName = auditLog.ServiceName,
                        UserName = joinedUser.UserName
                    };

            if (model.StartDate.HasValue)
            {
                model.StartDate = model.StartDate.Value.Date;
            }

            if (model.EndDate.HasValue)
            {
                model.EndDate = model.EndDate.Value.Date.AddDays(1).AddMilliseconds(-1);
            }

            query = query
                .WhereIf(model.StartDate.HasValue, item => item.ExecutionTime >= model.StartDate)
                .WhereIf(model.EndDate.HasValue, item => item.ExecutionTime <= model.EndDate)
                .WhereIf(!model.UserName.IsNullOrWhiteSpace(), item => item.UserName.Contains(model.UserName))
                .WhereIf(!model.ServiceName.IsNullOrWhiteSpace(),
                    item => item.ServiceName.Contains(model.ServiceName))
                .WhereIf(!model.MethodName.IsNullOrWhiteSpace(),
                    item => item.MethodName.Contains(model.MethodName))
                .WhereIf(!model.BrowserInfo.IsNullOrWhiteSpace(),
                    item => item.BrowserInfo.Contains(model.BrowserInfo))
                .WhereIf(model.MinExecutionDuration.HasValue && model.MinExecutionDuration > 0,
                    item => item.ExecutionDuration >= model.MinExecutionDuration.Value)
                .WhereIf(model.MaxExecutionDuration.HasValue && model.MaxExecutionDuration < int.MaxValue,
                    item => item.ExecutionDuration <= model.MaxExecutionDuration.Value)
                .WhereIf(model.HasException == true,
                    item => item.Exception != null && item.Exception != "")
                .WhereIf(model.HasException == false,
                    item => item.Exception == null || item.Exception == "");

            return query;
        }
    }
}
