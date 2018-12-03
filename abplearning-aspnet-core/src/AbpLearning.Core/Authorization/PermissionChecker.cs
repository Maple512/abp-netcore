using Abp.Authorization;
using AbpLearning.Authorization.Roles;
using AbpLearning.Authorization.Users;

namespace AbpLearning.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
