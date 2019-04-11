namespace AbpLearning.Application.MultiTenancy.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using Abp.MultiTenancy;

    public class TenantGetUpdateOutput : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }

        public string ConnectionString { get; set; }

        public bool IsActive { get; set; }
    }
}
