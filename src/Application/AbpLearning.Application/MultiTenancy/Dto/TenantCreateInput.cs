namespace AbpLearning.Application.MultiTenancy.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using Abp.Authorization.Users;
    using Abp.AutoMapper;
    using Abp.MultiTenancy;
    using AbpLearning.Core.MultiTenancy;

    [AutoMapTo(typeof(Tenant))]
    public class TenantCreateInput : NullableIdDto
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
