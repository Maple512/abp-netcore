namespace AbpLearning.Core.CloudBookList
{
    using System.Linq;
    using Abp.Authorization;
    using Abp.Configuration.Startup;
    using Base;

    public abstract class CloudBookListAuthorizationProvider : AuthorizationProviderBase
    {
        protected CloudBookListAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig) : base(multiTenancyConfig)
        {
        }

        protected CloudBookListAuthorizationProvider(bool isMultiTenancyEnabled) : base(isMultiTenancyEnabled)
        {
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.GetPermissionOrNull(AbpLearningPermissions.PAGES);

            CloudBookListPermission = pages.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.CLOUDBOOKLIST) ?? pages.CreateChildPermission(AbpLearningPermissions.CLOUDBOOKLIST, L("CloudBookList"));
        }

        public Permission CloudBookListPermission { get; private set; }
    }
}
