namespace AbpLearning.Application.Users.Dto
{
    using System;
    using Abp.Application.Services.Dto;

    public class UserGetUpdateOutput : EntityDto<long>
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime CreationTime { get; set; }

        public string[] RoleNames { get; set; }
    }
}
