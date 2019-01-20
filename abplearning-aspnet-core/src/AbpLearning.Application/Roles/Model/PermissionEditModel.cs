namespace AbpLearning.Application.Roles.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Authorization;

    /// <summary>
    /// <see cref="Permission"/> 更新模型
    /// </summary>
    public class PermissionEditModel
    {
        /// <summary>
        /// 角色
        /// </summary>
        [Required]
        public int RoleId { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        [Required]
        public List<string> Permissions { get; set; }
    }
}
