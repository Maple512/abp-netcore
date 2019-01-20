namespace AbpLearning.Application.Roles.Model
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using Abp.Authorization.Roles;
    using Abp.AutoMapper;
    using Core.Authorization.Roles;

    /// <summary>
    /// <see cref="Role"/> 更新模型
    /// </summary>
    [AutoMap(typeof(Role))]
    public class RoleEditModel : EntityDto<int>
    {
        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpRoleBase.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        [StringLength(Role.MaxDescriptionLength)]
        public string Description { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }
    }
}
