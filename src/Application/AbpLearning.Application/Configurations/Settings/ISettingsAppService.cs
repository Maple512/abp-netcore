namespace AbpLearning.Application.Configurations.Settings
{
    using Abp.Application.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Dto;

    public interface ISettingsAppService : IApplicationService
    {
        /// <summary>
        /// All scope settings
        /// </summary>
        /// <returns></returns>
        Task<AllScopesSettingsDto> GetAllScopesSettingsAsync();

        /// <summary>
        /// Application scope settings
        /// </summary>
        /// <returns></returns>
        Task<ApplicationSettingsDto> GetApplicationSettingsAsync();

        /// <summary>
        /// Tenant  scope settings
        /// </summary>
        /// <returns></returns>
        Task<TenantSettingsDto> GetTenantSettingsAsync();

        /// <summary>
        /// User  scope settings
        /// </summary>
        /// <returns></returns>
        Task<UserSettingsDto> GetUserSettingsAsync();
    }
}
