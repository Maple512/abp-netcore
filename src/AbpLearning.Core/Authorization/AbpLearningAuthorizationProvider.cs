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
            var pages = context.CreatePermission(AbpLearningPermissions.Pages, L("Pages"));

            #region authentication

            var authentication = pages.CreateChildPermission(AbpLearningPermissions.Authentication, L("Authentication"));

            authentication.CreateChildPermission(AbpLearningPermissions.User, L("User"))
                .CreateChildPermission(AbpLearningPermissions.User + AbpLearningPermissions.Action.Query, L("UserQuery"))
                .CreateChildPermission(AbpLearningPermissions.User + AbpLearningPermissions.Action.Create, L("UserCreate"))
                .CreateChildPermission(AbpLearningPermissions.User + AbpLearningPermissions.Action.Update, L("UserUpdate"))
                .CreateChildPermission(AbpLearningPermissions.User + AbpLearningPermissions.Action.Delete, L("UserDelete"))
                .CreateChildPermission(AbpLearningPermissions.User + AbpLearningPermissions.Action.BatchdDelete, L("UserBatchDelete"));

            authentication.CreateChildPermission(AbpLearningPermissions.Role, L("Role"))
                .CreateChildPermission(AbpLearningPermissions.Role + AbpLearningPermissions.Action.Query, L("UserQuery"))
                .CreateChildPermission(AbpLearningPermissions.Role + AbpLearningPermissions.Action.Create, L("UserCreate"))
                .CreateChildPermission(AbpLearningPermissions.Role + AbpLearningPermissions.Action.Update, L("UserUpdate"))
                .CreateChildPermission(AbpLearningPermissions.Role + AbpLearningPermissions.Action.Delete, L("UserDelete"))
                .CreateChildPermission(AbpLearningPermissions.Role + AbpLearningPermissions.Action.BatchdDelete, L("UserBatchDelete")); ;

            authentication.CreateChildPermission(AbpLearningPermissions.Tenant, L("Tenant"), multiTenancySides: MultiTenancySides.Host);

            #endregion

            #region system

            var system = pages.CreateChildPermission(AbpLearningPermissions.System, L("System"));

            system.CreateChildPermission(AbpLearningPermissions.AuditLog, L("AuditLog"));

            #endregion
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpLearningConsts.LocalizationSourceName);
        }
    }
}
