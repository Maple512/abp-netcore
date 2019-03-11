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

            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Query, L("BookList Query"), L("BookList Query Description"));
            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Create, L("BookList Create"), L("BookList Create Description"));
            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Update, L("BookList Edit"), L("BookList Edit Description"));
            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Delete, L("BookList Delete"), L("BookList Delete Description"));
            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.BatchdDelete, L("BookList BatchDelete"), L("BookList BatchDelete Description"));
            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.ExportExcel, L("BookList ExportExcel"), L("BookList ExportExcel Description"));
        }
    }
}
