namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Entities.Auditing;

    public class RoleGetPagedOutput : EntityDto, IHasModificationTime
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool IsDefault { get; set; }

        public bool IsStatic { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
