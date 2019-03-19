namespace AbpLearning.Application.MultiTenancy.Dto
{
    using Base;

    public class TenantGetViewOutput : INullIdEntityDto
    {
        /// <summary>
        /// 租户名
        /// </summary>
        public string Name { get; set; }
    }
}
