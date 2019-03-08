namespace AbpLearning.Application.MultiTenancy.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using Abp.MultiTenancy;

    public class TenantGetUpdateOutput : EntityDto
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
