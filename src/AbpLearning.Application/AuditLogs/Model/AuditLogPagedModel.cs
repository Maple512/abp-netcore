namespace AbpLearning.Application.AuditLogs.Model
{
    using System;
    using Abp.Application.Services.Dto;

    public class AuditLogPagedModel : EntityDto<long>
    {
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
        /// 参数
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        public DateTime ExecutionTime { get; set; }

        /// <summary>
        /// 执行持续时间
        /// </summary>
        public int ExecutionDuration { get; set; }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIPAddress { get; set; }

        /// <summary>
        /// 客户端名
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 浏览器信息
        /// </summary>
        public string BrowserInfo { get; set; }

        /// <summary>
        /// 异常
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// 自定义数据
        /// </summary>
        public string CustomData { get; set; }
    }
}
