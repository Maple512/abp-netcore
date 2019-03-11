namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;

    public class RoleUpdateDto : EntityDto
    {
        /// <summary>
        /// Unique name of this role
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// display name
        /// </summary>
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// if true,this role will be the default role for new users
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// if true,this role can not be delete,can not change their name
        /// </summary>
        public bool IsStatic { get; set; }
    }
}
