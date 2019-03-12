namespace AbpLearning.Application.Users.Dto
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using AbpLearning.Core.Authorization.Users;

    [AutoMapFrom(typeof(User))]
    public class UserGetPagedOutput : EntityDto<long>
    {
        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// Gets or sets the lockout enabled.
        /// </summary>
        public virtual bool IsLockoutEnabled { get; set; }
    }
}
