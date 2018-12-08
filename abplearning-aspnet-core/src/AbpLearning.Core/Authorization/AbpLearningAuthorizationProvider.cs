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
            context.CreatePermission(AbpLearningPermissions.ADMINISTRATOR, L("Administrator"))
                .CreateChildPermission(AbpLearningPermissions.USERS, L("Users"))
                .CreateChildPermission(AbpLearningPermissions.ROLES, L("Roles"))
                .CreateChildPermission(AbpLearningPermissions.TENANTS, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            // 页面
            context.CreatePermission(AbpLearningPermissions.PAGES, L("Pages"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpLearningConsts.LocalizationSourceName_Core);
        }
    }
}
