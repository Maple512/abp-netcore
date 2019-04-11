namespace AbpLearning.Core.Authorization
{
    using Abp.Authorization;
    using AbpLearning.Core.Authorization.Roles;
    using AbpLearning.Core.Authorization.Users;

    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
