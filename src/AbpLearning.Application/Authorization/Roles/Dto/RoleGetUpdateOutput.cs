namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;
    using AbpLearning.Application.Authorization.Permissions.Dto;

    public class RoleGetUpdateOutput : EntityDto
    {
        /// <summary>
        /// role
        /// </summary>
        public RoleUpdateDto Role { get; set; }

        /// <summary>
        /// all permisssion
        /// </summary>
        public PermissionGetViewOutput Permissions { get; set; }

        /// <summary>
        /// permissions granted to this role
        /// </summary>
        public List<string> GrantedPermissionNames { get; set; }
    }
}
