namespace AbpLearning.Core.CloudBookList.Book.Authorization
{
    using System.Linq;
    using Abp.Authorization;
    using Abp.Configuration.Startup;

    public class BookAuthorizationProvider : CloudBookListAuthorizationProvider
    {
        public BookAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig) : base(multiTenancyConfig)
        {
        }

        public BookAuthorizationProvider(bool isMultiTenancyEnabled) : base(isMultiTenancyEnabled)
        {
        }

        /// <summary>
        /// 在 Pages 下配置 Book 权限
        /// </summary>
        /// <param name="context"></param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            base.SetPermissions(context);

            var books = CloudBookListPermission.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.BOOK_NODE) ?? CloudBookListPermission.CreateChildPermission(AbpLearningPermissions.BOOK_NODE, L("Book"));

            books.CreateChildPermission(AbpLearningPermissions.BOOK_NODE + AbpLearningPermissions.QUERY, L("BookQuery"))
                .CreateChildPermission(AbpLearningPermissions.BOOK_NODE + AbpLearningPermissions.CREATE, L("BookCreate"))
                .CreateChildPermission(AbpLearningPermissions.BOOK_NODE + AbpLearningPermissions.EDIT, L("BookEdit"))
                .CreateChildPermission(AbpLearningPermissions.BOOK_NODE + AbpLearningPermissions.DELETE, L("BookDelete"))
                .CreateChildPermission(AbpLearningPermissions.BOOK_NODE + AbpLearningPermissions.BATCHD_DELETE, L("BookBatchDelete"))
                .CreateChildPermission(AbpLearningPermissions.BOOK_NODE + AbpLearningPermissions.EXPORT_EXCEL, L("BookExportExcel"));
        }
    }
}
