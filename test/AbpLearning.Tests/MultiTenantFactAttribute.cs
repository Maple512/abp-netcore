using AbpLearning.Core;
using Xunit;

namespace AbpLearning.Tests
{
    public sealed class MultiTenantFactAttribute : FactAttribute
    {
        public MultiTenantFactAttribute()
        {
            if (!AbpLearningCoreConfig.MULTI_TENANCY_ENABLED)
            {
                Skip = "MultiTenancy is disabled.";
            }
        }
    }
}
