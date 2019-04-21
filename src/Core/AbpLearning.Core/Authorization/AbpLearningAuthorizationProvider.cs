namespace AbpLearning.Core.Authorization
{
    using Abp.Authorization;
    using Abp.Localization;
    using Abp.MultiTenancy;

    public class AbpLearningAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // pages
            var pages = context.CreatePermission(AbpLearningPermissions.Pages, L("Pages.Permission"), L("Pages.Permission.Description"));

            #region system

            var system = pages.CreateChildPermission(AbpLearningPermissions.System, L("System.Permission"), L("System.Permission.Description"));

            var user = system.CreateChildPermission(AbpLearningPermissions.User, L("User.Permission"), L("User.Permission.Description"));

            var role = system.CreateChildPermission(AbpLearningPermissions.Role, L("Role.Permission"));

            var tenant = system.CreateChildPermission(AbpLearningPermissions.Tenant, L("Tenant.Permission"), L("Tenant.Permission.Description"), multiTenancySides: MultiTenancySides.Host);

            var auditlog = system.CreateChildPermission(AbpLearningPermissions.AuditLog, L("AuditLog.Permission"), L("AuditLog.Permission.Description"));

            var organization = system.CreateChildPermission(AbpLearningPermissions.Organization, L("Organization.Permission"), L("Organization.Permission.Description"));

            var setting = system.CreateChildPermission(AbpLearningPermissions.Setting, L("Setting.Permission"), L("Setting.Permission.Description"));

            var language = system.CreateChildPermission(AbpLearningPermissions.Language, L("Language.Permission"), L("Language.Permission.Description"));

            #endregion
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpLearningCoreConfig.LOCALIZATION_SOURCE_NAME);
        }

        public static AuthorizationProvider[] GetAllPermission()
        {
            return new[]
            {
                new AbpLearningAuthorizationProvider()
            };
        }
    }
}
