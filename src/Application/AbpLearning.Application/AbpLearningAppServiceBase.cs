namespace AbpLearning.Application
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Abp.Application.Services;
    using Abp.Runtime.Session;
    using AbpLearning.Core.Authorization.Users;
    using AbpLearning.Core.MultiTenancy;
    using Core;
    using Abp.IdentityFramework;

    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class AbpLearningAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected AbpLearningAppServiceBase()
        {
            LocalizationSourceName = AbpLearningCoreConfig.LOCALIZATION_SOURCE_NAME;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
