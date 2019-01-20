namespace AbpLearning.Application.Roles.Model
{
    using System.Collections.Generic;
    using Base;

    /// <summary>
    /// <see cref="RolePagedModel"/> 过滤/排序 模型
    /// </summary>
    /// <inheritdoc cref="PagedFilteringBaseModel"/>
    public class RolePagedFilteringModel : PagedFilteringBaseModel
    {
        /// <summary>
        /// 拥有的权限
        /// </summary>
        public List<string> PermissionNames { get; set; }
    }
}
