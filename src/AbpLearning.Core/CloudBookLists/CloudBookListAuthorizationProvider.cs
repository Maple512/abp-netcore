namespace AbpLearning.Core.CloudBookLists
{
    using System.Linq;
    using Abp.Authorization;
    using Abp.Configuration.Startup;
    using Base;

    public class CloudBookListAuthorizationProvider : AuthorizationProviderBase
    {
        public CloudBookListAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig) : base(multiTenancyConfig)
        {
        }

        public CloudBookListAuthorizationProvider(bool isMultiTenancyEnabled) : base(isMultiTenancyEnabled)
        {
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.GetPermissionOrNull(AbpLearningPermissions.Pages);

            var cloudbooklist = pages.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.Cloudbooklist)
                ?? pages.CreateChildPermission(AbpLearningPermissions.Cloudbooklist, L("CloudBookList"), L("CloudBookList Desctiption"));

            var books = cloudbooklist.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.Book) ?? cloudbooklist.CreateChildPermission(AbpLearningPermissions.Book, L("Book"));
            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.Query, L("Book Query"), L("Book Query Description"));
            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.Create, L("Book Create"), L("Book Create Description"));
            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.Update, L("Book Edit"), L("Book Edit Description"));
            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.Delete, L("Book Delete"), L("Book Delete Description"));
            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.BatchdDelete, L("Book BatchDelete"), L("Book BatchDelete Description"));
            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.ExportExcel, L("Book ExportExcel"), L("Book ExportExcel Description"));

            var bookList = cloudbooklist.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.Booklist) ?? cloudbooklist.CreateChildPermission(AbpLearningPermissions.Booklist, L("BookList"));
            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Query, L("BookList Query"), L("BookList Query Description"));
            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Create, L("BookList Create"), L("BookList Create Description"));
            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Update, L("BookList Edit"), L("BookList Edit Description"));
            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Delete, L("BookList Delete"), L("BookList Delete Description"));
            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.BatchdDelete, L("BookList BatchDelete"), L("BookList BatchDelete Description"));
            bookList.CreateChildPermission(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.ExportExcel, L("BookList ExportExcel"), L("BookList ExportExcel Description"));
        }
    }
}
