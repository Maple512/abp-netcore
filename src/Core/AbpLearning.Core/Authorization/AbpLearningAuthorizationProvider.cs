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
            var pages = context.CreatePermission(AbpLearningPermissions.Pages, L("Pages"), L("Pages Description"));

            #region system

            var system = pages.CreateChildPermission(AbpLearningPermissions.System, L("System"), L("System Description"));

            var user = system.CreateChildPermission(AbpLearningPermissions.User, L("User"), L("User Description"));

            var role = system.CreateChildPermission(AbpLearningPermissions.Role, L("Role"));

            var tenant = system.CreateChildPermission(AbpLearningPermissions.Tenant, L("Tenant"), L("Tenant Description"), multiTenancySides: MultiTenancySides.Host);

            var auditlog = system.CreateChildPermission(AbpLearningPermissions.AuditLog, L("AuditLog"), L("AuditLog Description"));

            var organization = system.CreateChildPermission(AbpLearningPermissions.Organization, L("Organization"), L("Organization Description"));

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
