namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;

    public class RoleUpdateInput: EntityDto
    {
        [Required]
        public RoleUpdateDto Role { get; set; }

        [Required]
        public List<string> GrantedPermission { get; set; }
    }
}
