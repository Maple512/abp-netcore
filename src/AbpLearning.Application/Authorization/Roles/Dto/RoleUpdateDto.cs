namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;

    public class RoleUpdateDto : EntityDto
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
