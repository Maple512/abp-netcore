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

            file.CreateChildPermission(AbpLearningPermissions.UploadFile + AbpLearningPermissions.Action.Query, L("UploadFileQuery"))
                .CreateChildPermission(AbpLearningPermissions.UploadFile + AbpLearningPermissions.Action.Upload, L("UploadFileUpload"))
                .CreateChildPermission(AbpLearningPermissions.UploadFile + AbpLearningPermissions.Action.Update, L("UploadFileEdit"))
                .CreateChildPermission(AbpLearningPermissions.UploadFile + AbpLearningPermissions.Action.Delete, L("UploadFileDelete"))
                .CreateChildPermission(AbpLearningPermissions.UploadFile + AbpLearningPermissions.Action.BatchdDelete, L("UploadFileBatchDelete"))
                .CreateChildPermission(AbpLearningPermissions.UploadFile + AbpLearningPermissions.Action.Download, L("UploadFileDownload"));
        }
    }
}
