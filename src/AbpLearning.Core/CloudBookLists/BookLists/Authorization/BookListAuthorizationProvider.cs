namespace AbpLearning.Core.CloudBookLists.BookLists.Authorization
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

            var bookList = CloudBookListPermission.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.Booklist) ?? CloudBookListPermission.CreateChildPermission(AbpLearningPermissions.Booklist, L("BookList"));

            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Query, L("BookListQuery"))
                .CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Create, L("BookListCreate"))
                .CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Update, L("BookListEdit"))
                .CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Delete, L("BookListDelete"))
                .CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.BatchdDelete, L("BookListBatchDelete"))
                .CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.ExportExcel, L("BookListExportExcel"));
        }
    }
}
