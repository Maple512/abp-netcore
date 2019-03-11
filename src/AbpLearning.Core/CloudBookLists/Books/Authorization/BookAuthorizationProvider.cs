namespace AbpLearning.Core.CloudBookLists.Books.Authorization
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

            var books = CloudBookListPermission.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.Book) ?? CloudBookListPermission.CreateChildPermission(AbpLearningPermissions.Book, L("Book"));

            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.Query, L("Book Query"), L("Book Query Description"));
            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.Create, L("Book Create"), L("Book Create Description"));
            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.Update, L("Book Edit"), L("Book Edit Description"));
            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.Delete, L("Book Delete"), L("Book Delete Description"));
            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.BatchdDelete, L("Book BatchDelete"), L("Book BatchDelete Description"));
            books.CreateChildPermission(AbpLearningPermissions.Book + AbpLearningPermissions.Action.ExportExcel, L("Book ExportExcel"), L("Book ExportExcel Description"));
        }
    }
}
