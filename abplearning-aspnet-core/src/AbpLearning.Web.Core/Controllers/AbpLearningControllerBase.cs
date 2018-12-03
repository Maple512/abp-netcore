using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AbpLearning.Controllers
{
    public abstract class AbpLearningControllerBase: AbpController
    {
        protected AbpLearningControllerBase()
        {
            LocalizationSourceName = AbpLearningConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
