using Abp.Authorization;
using AbpLearning.Core.Authorization.Roles;
using AbpLearning.Core.Authorization.Users;

namespace AbpLearning.Core.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
