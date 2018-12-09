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

            var bookTags = CloudBookListPermission.Children.FirstOrDefault(m => m.Name == AbpLearningPermissions.BooktagNode) ?? CloudBookListPermission.CreateChildPermission(AbpLearningPermissions.BooktagNode, L("BookTag"));

            bookTags.CreateChildPermission(AbpLearningPermissions.BooktagNode + AbpLearningPermissions.Query, L("BookTagQuery"))
                .CreateChildPermission(AbpLearningPermissions.BooktagNode + AbpLearningPermissions.Create, L("BookTagCreate"))
                .CreateChildPermission(AbpLearningPermissions.BooktagNode + AbpLearningPermissions.Edit, L("BookTagEdit"))
                .CreateChildPermission(AbpLearningPermissions.BooktagNode + AbpLearningPermissions.Delete, L("BookTagDelete"))
                .CreateChildPermission(AbpLearningPermissions.BooktagNode + AbpLearningPermissions.BatchdDelete, L("BookTagBatchDelete"))
                .CreateChildPermission(AbpLearningPermissions.BooktagNode + AbpLearningPermissions.ExportExcel, L("BookTagExportExcel"));
        }
    }
}
