namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AbpLearning.Application.Base;

    public class RoleCreateInput : INullIdEntityDto
    {
        /// <summary>
        /// role nme(unique)
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// display name
        /// </summary>
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// role-owned permisssions
        /// </summary>
        public List<string> GrantedPermissions { get; set; }

        /// <summary>
        /// if true,this role can not be delete,can not change their name
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
