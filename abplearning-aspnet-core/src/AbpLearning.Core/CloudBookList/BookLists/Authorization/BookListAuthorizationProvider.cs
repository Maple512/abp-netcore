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

            var bookList = CloudBookListPermission.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.BooklistNode) ?? CloudBookListPermission.CreateChildPermission(AbpLearningPermissions.BooklistNode, L("BookList"));

            bookList.CreateChildPermission(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Query, L("BookListQuery"))
                .CreateChildPermission(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Create, L("BookListCreate"))
                .CreateChildPermission(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Edit, L("BookListEdit"))
                .CreateChildPermission(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Delete, L("BookListDelete"))
                .CreateChildPermission(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.BatchdDelete, L("BookListBatchDelete"))
                .CreateChildPermission(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.ExportExcel, L("BookListExportExcel"));
        }
    }
}
