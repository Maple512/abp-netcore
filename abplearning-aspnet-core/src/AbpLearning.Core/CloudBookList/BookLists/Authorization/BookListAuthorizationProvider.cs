namespace AbpLearning.Core.CloudBookList.BookLists.Authorization
{
    using System.Linq;
    using Abp.Authorization;
    using Abp.Configuration.Startup;

    public class BookListAuthorizationProvider : CloudBookListAuthorizationProvider
    {
        public BookListAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig) : base(multiTenancyConfig)
        {
        }

        public BookListAuthorizationProvider(bool isMultiTenancyEnabled) : base(isMultiTenancyEnabled)
        {
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            base.SetPermissions(context);

            var bookList = CloudBookListPermission.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.BOOKLIST_NODE) ?? CloudBookListPermission.CreateChildPermission(AbpLearningPermissions.BOOKLIST_NODE, L("BookList"));

            bookList.CreateChildPermission(AbpLearningPermissions.BOOKLIST_NODE + AbpLearningPermissions.QUERY, L("BookListQuery"))
                .CreateChildPermission(AbpLearningPermissions.BOOKLIST_NODE + AbpLearningPermissions.CREATE, L("BookListCreate"))
                .CreateChildPermission(AbpLearningPermissions.BOOKLIST_NODE + AbpLearningPermissions.EDIT, L("BookListEdit"))
                .CreateChildPermission(AbpLearningPermissions.BOOKLIST_NODE + AbpLearningPermissions.DELETE, L("BookListDelete"))
                .CreateChildPermission(AbpLearningPermissions.BOOKLIST_NODE + AbpLearningPermissions.BATCHD_DELETE, L("BookListBatchDelete"))
                .CreateChildPermission(AbpLearningPermissions.BOOKLIST_NODE + AbpLearningPermissions.EXPORT_EXCEL, L("BookListExportExcel"));
        }
    }
}
