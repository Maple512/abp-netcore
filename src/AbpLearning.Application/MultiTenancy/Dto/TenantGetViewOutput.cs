namespace AbpLearning.Application.MultiTenancy.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using AbpLearning.Core.MultiTenancy;

    [AutoMapFrom(typeof(Tenant))]
    public class TenantGetViewOutput:NullableIdDto
    {
        /// <summary>
        /// 租户名
        /// </summary>
        public string Name { get; set; }
    }
}
