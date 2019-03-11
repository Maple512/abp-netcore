namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using System.Collections.Generic;
    using Base;

    public class RoleGetPagedInput : PagedFilteringModelBase
    {
        /// <summary>
        /// 权限名
        /// </summary>
        public List<string> PermissionNames { get; set; }
    }
}
