namespace AbpLearning.Application.Roles.Model
{
    using Abp.Authorization;
    using Abp.AutoMapper;

    /// <summary>
    /// <see cref="Permission"/> 视图模型
    /// </summary>
    [AutoMapFrom(typeof(Permission))]
    public class PermissionViewModel
    {
        /// <summary>
        /// 权限名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
