namespace AbpLearning.Core.Files
{
    using System.Linq;
    using Abp.Authorization;
    using Abp.Configuration.Startup;
    using Base;

    public class FileAuthorizationProvider : AuthorizationProviderBase
    {
        public FileAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig) : base(multiTenancyConfig)
        {
        }

        public FileAuthorizationProvider(bool isMultiTenancyEnabled) : base(isMultiTenancyEnabled)
        {
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.GetPermissionOrNull(AbpLearningPermissions.Pages);

            var file = pages.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.File) ?? pages.CreateChildPermission(AbpLearningPermissions.File, L("File"));

            file.CreateChildPermission(AbpLearningPermissions.File + AbpLearningPermissions.Action.Query, L("File Query"), L("File Query Description"));
            file.CreateChildPermission(AbpLearningPermissions.File + AbpLearningPermissions.Action.Upload, L("File Upload"), L("File Upload Description"));
            file.CreateChildPermission(AbpLearningPermissions.File + AbpLearningPermissions.Action.Update, L("File Edit"), L("File Edit Description"));
            file.CreateChildPermission(AbpLearningPermissions.File + AbpLearningPermissions.Action.Delete, L("File Delete"), L("File Delete Description"));
            file.CreateChildPermission(AbpLearningPermissions.File + AbpLearningPermissions.Action.BatchdDelete, L("Upload ile BatchDelete"), L("File BatchDelete Description"));
            file.CreateChildPermission(AbpLearningPermissions.File + AbpLearningPermissions.Action.Download, L("File Download"), L("File Download Description"));
        }
    }
}
