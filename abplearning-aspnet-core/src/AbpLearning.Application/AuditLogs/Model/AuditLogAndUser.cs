namespace AbpLearning.Application.AuditLogs.Model
{
    using Abp.Auditing;
    using AbpLearning.Core.Authorization.Users;

    public class AuditLogAndUser
    {
        public AuditLog AuditLogInfo { get; set; }

        public User UserInfo { get; set; }
    }
}
