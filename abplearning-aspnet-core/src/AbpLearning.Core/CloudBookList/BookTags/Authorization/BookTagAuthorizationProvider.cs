namespace AbpLearning.Core.CloudBookList.BookTags.Authorization
{
    using System.Linq;
    using Abp.Authorization;
    using Abp.Configuration.Startup;

    public class BookTagAuthorizationProvider : CloudBookListAuthorizationProvider
    {
        public BookTagAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig) : base(multiTenancyConfig)
        {
        }

        public BookTagAuthorizationProvider(bool isMultiTenancyEnabled) : base(isMultiTenancyEnabled)
        {
        }

        /// <summary>
        /// 在 Pages.CloudBookList 下配置 BookTag 权限
        /// </summary>
        /// <param name="context"></param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            base.SetPermissions(context);

            var bookTags = CloudBookListPermission.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.BOOKTAG_NODE) ?? CloudBookListPermission.CreateChildPermission(AbpLearningPermissions.BOOKTAG_NODE, L("BookTag"));

            bookTags.CreateChildPermission(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.QUERY, L("BookTagQuery"))
                .CreateChildPermission(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.CREATE, L("BookTagCreate"))
                .CreateChildPermission(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.EDIT, L("BookTagEdit"))
                .CreateChildPermission(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.DELETE, L("BookTagDelete"))
                .CreateChildPermission(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.BATCHD_DELETE, L("BookTagBatchDelete"))
                .CreateChildPermission(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.EXPORT_EXCEL, L("BookTagExportExcel"));
        }
    }
}
