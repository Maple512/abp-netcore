namespace AbpLearning.Web.Host.Filter
{
    using LogDashboard;
    using LogDashboard.Authorization;
    using Microsoft.AspNetCore.Http.Extensions;

    /// <summary>
    /// <see cref="LogDashboard"/> 授权过滤器
    /// </summary>
    public class SamplesAuthorizationFilter : ILogDashboardAuthorizationFilter
    {
        public bool Authorization(LogDashboardContext context)
        {
            var url = context.HttpContext.Request.GetDisplayUrl();

            // 判断IP是否本地
            return url.Contains("localhost") || url.Contains("127.0.0.1");
        }
    }
}
