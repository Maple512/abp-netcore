namespace AbpLearning.Application.Authorization.Permissions
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Authorization;
    using Abp.Runtime.Validation;

    public static class PermissionManagerExtensions
    {
        /// <summary>
        /// get all permissions by names
        /// </summary>
        /// <param name="permissionManager"></param>
        /// <param name="permissionNames"></param>
        /// <returns></returns>
        public static IEnumerable<Permission> GetAllPermissionsByNames(
            this IPermissionManager permissionManager, IEnumerable<string> permissionNames)
        {
            var permissions = new List<Permission>();
            var undefinedPermissionNames = new List<string>();

            foreach (var permissionName in permissionNames)
            {
                var permission = permissionManager.GetPermissionOrNull(permissionName);
                if (permission == null) undefinedPermissionNames.Add(permissionName);

                permissions.Add(permission);
            }

            if (undefinedPermissionNames.Count > 0)
                throw new AbpValidationException(
                    $"There are {undefinedPermissionNames.Count} undefined permission names.")
                {
                    ValidationErrors = undefinedPermissionNames.ConvertAll(permissionName =>
                        new ValidationResult("Undefined permission: " + permissionName))
                };

            return permissions;
        }
    }
}
