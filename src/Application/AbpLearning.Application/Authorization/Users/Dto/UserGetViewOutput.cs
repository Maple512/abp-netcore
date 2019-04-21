namespace AbpLearning.Application.Authorization.Users.Dto
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using AbpLearning.Core.Authorization.Users;

    [AutoMapFrom(typeof(User))]
    public class UserGetViewOutput : NullableIdDto<long>
    {
        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public string[] RoleNames { get; set; }
    }
}
