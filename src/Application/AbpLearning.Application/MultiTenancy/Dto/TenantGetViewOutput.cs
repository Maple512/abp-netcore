namespace AbpLearning.Application.MultiTenancy.Dto
{
    using Abp.Application.Services.Dto;

    public class TenantGetViewOutput : NullableIdDto
    {
        /// <summary>
        /// 租户名
        /// </summary>
        public string Name { get; set; }
    }
}
