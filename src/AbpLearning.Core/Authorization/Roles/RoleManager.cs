using System.Threading.Tasks;

namespace AbpLearning.Core.Authorization.Roles
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Abp.Authorization;
    using Abp.Authorization.Roles;
    using Abp.Domain.Uow;
    using Abp.Runtime.Caching;
    using Abp.Zero.Configuration;
    using Users;

    public class RoleManager : AbpRoleManager<Role, User>
    {
        public RoleManager(
            RoleStore store, 
            IEnumerable<IRoleValidator<Role>> roleValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            ILogger<AbpRoleManager<Role, User>> logger,
            IPermissionManager permissionManager, 
            ICacheManager cacheManager, 
            IUnitOfWorkManager unitOfWorkManager,
            IRoleManagementConfig roleManagementConfig)
            : base(
                  store,
                  roleValidators, 
                  keyNormalizer, 
                  errors, logger, 
                  permissionManager,
                  cacheManager, 
                  unitOfWorkManager,
                  roleManagementConfig)
        {
        }

        //public override Task<IdentityResult> CheckDuplicateRoleNameAsync(int? expectedRoleId, string name, string displayName)
        //{
        //    AbpRoleManager<TRole, TUser> abpRoleManager = this;
        //    TRole byNameAsync = await abpRoleManager.FindByNameAsync(name);
        //    if ((Entity<int>)byNameAsync != (Entity<int>)null)
        //    {
        //        int id = byNameAsync.Id;
        //        int? nullable = expectedRoleId;
        //        int valueOrDefault = nullable.GetValueOrDefault();
        //        if (!(id == valueOrDefault & nullable.HasValue))
        //            throw new UserFriendlyException(string.Format(abpRoleManager.L("RoleNameIsAlreadyTaken"), (object)name));
        //    }
        //    TRole displayNameAsync = await abpRoleManager.FindByDisplayNameAsync(displayName);
        //    if ((Entity<int>)displayNameAsync != (Entity<int>)null)
        //    {
        //        int id = displayNameAsync.Id;
        //        int? nullable = expectedRoleId;
        //        int valueOrDefault = nullable.GetValueOrDefault();
        //        if (!(id == valueOrDefault & nullable.HasValue))
        //            throw new UserFriendlyException(string.Format(abpRoleManager.L("RoleDisplayNameIsAlreadyTaken"), (object)displayName));
        //    }
        //    return IdentityResult.Success;
        //}
    }
}
