namespace AbpLearning.Application.AuditLogs.Model
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.Extensions;
    using Abp.Runtime.Validation;

    public class AuditLogPagedFilteringModel : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 执行起始时间
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 执行结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 服务名
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 浏览器信息
        /// </summary>
        public string BrowserInfo { get; set; }

        /// <summary>
        /// 是否存在异常
        /// </summary>
        public bool? HasException { get; set; }

        /// <summary>
        /// 最小持续时间
        /// </summary>
        public int? MinExecutionDuration { get; set; }

        /// <summary>
        /// 最大持续时间
        /// </summary>
        public int? MaxExecutionDuration { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "ExecutionTime DESC";
            }
        }
    }
}
