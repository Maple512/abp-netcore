namespace AbpLearning.Application.AuditLogs.Model
{
    using System;
    using Abp.Extensions;
    using AbpLearning.Application.Base;

    public class AuditLogPagedFilteringModel : PagedFilteringBaseModel
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string UserName { get; set; }

        public string ServiceName { get; set; }

        public string MethodName { get; set; }

        public string BrowserInfo { get; set; }

        public bool? HasException { get; set; }

        public int? MinExecutionDuration { get; set; }

        public int? MaxExecutionDuration { get; set; }

        public override void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "ExecutionTime DESC";
            }

            if (Sorting.IndexOf("UserName", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                Sorting = "UserInfo." + Sorting;
            }
            else
            {
                Sorting = "AuditLogInfo." + Sorting;
            }
        }
    }
}
