namespace AbpLearning.Application.Users.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using Abp.Authorization.Users;

    public class UserUpdateInput : EntityDto<long>
    {
        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime CreationTime { get; set; }

        public string[] RoleNames { get; set; }
    }
}
