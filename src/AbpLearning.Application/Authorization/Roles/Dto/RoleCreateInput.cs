namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AbpLearning.Application.Base;

    public class RoleCreateInput : INullIdEntityDto
    {
        /// <summary>
        /// 显示名
        /// </summary>
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// 角色拥有的权限
        /// </summary>
        public List<string> GrantedPermissions { get; set; }

        /// <summary>
        /// 是否默认（新用户默认拥有)
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
