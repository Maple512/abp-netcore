namespace AbpLearning.Core.Authorization
{
    using Abp.Authorization;
    using Abp.Localization;
    using Abp.MultiTenancy;

    public class AbpLearningAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // 管理员 权限
            context.CreatePermission(AbpLearningPermissions.Administrator, L("Administrator"))
                .CreateChildPermission(AbpLearningPermissions.Users, L("Users"))
                .CreateChildPermission(AbpLearningPermissions.Roles, L("Roles"))
                .CreateChildPermission(AbpLearningPermissions.Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            // 页面
            context.CreatePermission(AbpLearningPermissions.Pages, L("Pages"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpLearningConsts.LocalizationSourceName_Core);
        }
    }
}
