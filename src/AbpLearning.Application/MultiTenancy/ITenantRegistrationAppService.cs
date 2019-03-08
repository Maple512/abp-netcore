namespace AbpLearning.Application.MultiTenancy
{
    using AbpLearning.Application.MultiTenancy.Dto;
    using AbpLearning.MultiTenancy.Dto;
    using System.Threading.Tasks;

    public interface ITenantRegistrationAppService
    {
        /// <summary>
        /// 注册租户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TenantUpdateInput> RegisterTenantAsync(TenantCreateInput input);
    }
}
