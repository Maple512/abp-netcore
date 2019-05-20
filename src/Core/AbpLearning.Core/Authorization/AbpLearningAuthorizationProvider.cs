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
            var pages = context.CreatePermission(AbpLearningPermissions.Pages, L("Permission.Pages"), L("Permission.Pages.Description"));

            SystemPermission(ref pages);

            PersonnelPermission(ref pages);
        }

        #region Private Permission

        private static void SystemPermission(ref Permission parent)
        {
            var system = parent.CreateChildPermission(AbpLearningPermissions.System, L("Permission.System"), L("Permission.System.Description"));

            var auditlog = system.CreateChildPermission(AbpLearningPermissions.AuditLog, L("Permission.AuditLog"), L("Permission.AuditLog.Description"));

            var setting = system.CreateChildPermission(AbpLearningPermissions.Setting, L("Permission.Setting.Permission"), L("Permission.Setting.Description"));

            var language = system.CreateChildPermission(AbpLearningPermissions.Language, L("Permission.Language.Permission"), L("Permission.Language.Description"));
        }

        private static void PersonnelPermission(ref Permission parent)
        {
            var personnel = parent.CreateChildPermission(AbpLearningPermissions.Personnel, L("Permission.Personnel"), L("Permission.Personnel.Description"));

            var user = personnel.CreateChildPermission(AbpLearningPermissions.User, L("Permission.User"), L("Permission.User.Description"));

            var role = personnel.CreateChildPermission(AbpLearningPermissions.Role, L("Permission.Role"));

            var tenant = personnel.CreateChildPermission(AbpLearningPermissions.Tenant, L("Permission.Tenant"), L("Permission.Tenant.Description"), multiTenancySides: MultiTenancySides.Host);

            var organization = personnel.CreateChildPermission(AbpLearningPermissions.Organization, L("Permission.Organization"), L("Permission.Organization.Description"));
        }

        #endregion

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
