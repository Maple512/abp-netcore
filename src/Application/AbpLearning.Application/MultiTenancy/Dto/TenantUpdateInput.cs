namespace AbpLearning.MultiTenancy.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using Abp.MultiTenancy;

    public class TenantUpdateInput : EntityDto
    {
        /// <summary>
        /// display name
        /// </summary>
        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }

        /// <summary>
        /// connection string
        /// </summary>
        public string ConnectionString { get; set; }

        public bool IsActive { get; set; }
    }
}
