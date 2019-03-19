namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using AbpLearning.Core.Authorization.Roles;

    [AutoMap(typeof(Role))]
    public class RoleUpdateDto : EntityDto
    {
        /// <summary>
        /// display name
        /// </summary>
        [Required]
        [MaxLength(Role.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(Role.MaxDescriptionLength)]
        public string Description { get; set; }

        /// <summary>
        /// if true,this role will be the default role for new users
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
