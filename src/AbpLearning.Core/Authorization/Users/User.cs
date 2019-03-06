namespace AbpLearning.Core.Authorization.Users
{
    using System;
    using Abp.Authorization.Users;
    using Abp.Extensions;

    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        /// <summary>
        /// Í·Ïñ
        /// </summary>
        public string Portrait { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
