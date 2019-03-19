namespace AbpLearning.Application.MultiTenancy.Dto
{
    using Abp.Application.Services.Dto;

    public class TenantGetPagedOutput : AuditedEntityDto
    {
        /// <summary>
        /// 唯一名
        /// </summary>
        public string TenancyName { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }
    }
}
