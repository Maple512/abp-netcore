namespace AbpLearning.Application.AuditLogs
{
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Auditing;
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using AbpLearning.Application.AuditLogs.Dto;
    using AbpLearning.Common.Extensions;
    using AbpLearning.Core;
    using AbpLearning.Core.Authorization.Users;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="AuditLogAppService" />
    /// </summary>
    [DisableAuditing]
    [AbpAuthorize(AbpLearningPermissions.AuditLog)]
    public class AuditLogAppService : AbpLearningAppServiceBase, IAuditLogAppService
    {
        /// <summary>
        /// Defines the _auditLog
        /// </summary>
        private readonly IRepository<AuditLog, long> _auditLog;

        /// <summary>
        /// Defines the _user
        /// </summary>
        private readonly IRepository<User, long> _user;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogAppService"/> class.
        /// </summary>
        /// <param name="auditLog">The auditLog<see cref="IRepository{AuditLog}"/></param>
        /// <param name="user">The user<see cref="IRepository{User}"/></param>
        public AuditLogAppService(IRepository<AuditLog, long> auditLog, IRepository<User, long> user)
        {
            _auditLog = auditLog;
            _user = user;
        }

        /// <summary>
        /// The GetPaged
        /// </summary>
        /// <param name="model">The model<see cref="AuditLogPagedFilteringModel"/></param>
        /// <returns>The <see cref="PagedResultDto{AuditLogPagedModel}"/></returns>
        public async Task<PagedResultDto<AuditLogGetPagedOutput>> GetPagedAsync(AuditLogGetPagedInput model)
        {
            var query = CreateAuditLogQuery(model);

            var count = await query.CountAsync();

            var result = await query.AsNoTracking()
                .OrderBy(model.Sorting)
                .PageBy(model)
                .ToListAsync();

            return new PagedResultDto<AuditLogGetPagedOutput>(count, result);
        }

        /// <summary>
        /// 构建审计日志查询语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private IQueryable<AuditLogGetPagedOutput> CreateAuditLogQuery(AuditLogGetPagedInput model)
        {
            var query = from auditLog in _auditLog.GetAll().AsNoTracking()
                join user in _user.GetAll().AsNoTracking() on auditLog.UserId equals user.Id
                    into userJoin
                from joinedUser in userJoin.DefaultIfEmpty()
                select new AuditLogGetPagedOutput
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
