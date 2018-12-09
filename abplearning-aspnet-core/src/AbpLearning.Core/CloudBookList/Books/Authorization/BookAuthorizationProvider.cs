namespace AbpLearning.Core.CloudBookList.Books.Authorization
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

            var books = CloudBookListPermission.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.BookNode) ?? CloudBookListPermission.CreateChildPermission(AbpLearningPermissions.BookNode, L("Book"));

            books.CreateChildPermission(AbpLearningPermissions.BookNode + AbpLearningPermissions.Query, L("BookQuery"))
                .CreateChildPermission(AbpLearningPermissions.BookNode + AbpLearningPermissions.Create, L("BookCreate"))
                .CreateChildPermission(AbpLearningPermissions.BookNode + AbpLearningPermissions.Edit, L("BookEdit"))
                .CreateChildPermission(AbpLearningPermissions.BookNode + AbpLearningPermissions.Delete, L("BookDelete"))
                .CreateChildPermission(AbpLearningPermissions.BookNode + AbpLearningPermissions.BatchdDelete, L("BookBatchDelete"))
                .CreateChildPermission(AbpLearningPermissions.BookNode + AbpLearningPermissions.ExportExcel, L("BookExportExcel"));
        }
    }
}
