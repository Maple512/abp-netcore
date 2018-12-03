using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace AbpLearning.Authorization
{
    public class AbpLearningAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            // 管理员 权限
            context.CreatePermission(PermissionNames.Administrator, L("Administrator"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpLearningConsts.LocalizationSourceName);
        }
    }
}
