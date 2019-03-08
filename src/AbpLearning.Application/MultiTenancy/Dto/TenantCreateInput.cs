namespace AbpLearning.Application.MultiTenancy.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Authorization.Users;
    using Abp.MultiTenancy;
    using Base;

    public class TenantCreateInput : INullIdEntityDto
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }
        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }

        [StringLength(AbpTenantBase.MaxConnectionStringLength)]
        public string ConnectionString { get; set; }

        public bool IsActive { get; set; }

        public string TenantAdminPassword { get; set; }
    }
}
