using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using AbpLearning.Core;
using Microsoft.AspNetCore.Identity;

namespace AbpLearning.Web.Core.Controllers
{
    public abstract class AbpLearningControllerBase: AbpController
    {
        protected AbpLearningControllerBase()
        {
            LocalizationSourceName = AbpLearningCoreConfig.LOCALIZATION_SOURCE_NAME;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
