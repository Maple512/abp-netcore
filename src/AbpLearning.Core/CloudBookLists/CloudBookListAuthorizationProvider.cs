namespace AbpLearning.Core.CloudBookLists
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
            var pages = context.GetPermissionOrNull(AbpLearningPermissions.Pages);

            CloudBookListPermission = pages.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.Cloudbooklist) ?? pages.CreateChildPermission(AbpLearningPermissions.Cloudbooklist, L("CloudBookList"));
        }

        protected Permission CloudBookListPermission { get; private set; }
    }
}
