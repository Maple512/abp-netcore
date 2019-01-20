namespace AbpLearning.Core.Authorization.Roles
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Authorization.Roles;
    using AbpLearning.Core.Authorization.Users;

    public class Role : AbpRole<User>
    {
        public const int MaxDescriptionLength = 512;

        public Role()
        {
        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {
        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {
        }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
