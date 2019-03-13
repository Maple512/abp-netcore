namespace AbpLearning.Application.Organizations.Dto
{
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Abp.Organizations;

    [AutoMapFrom(typeof(OrganizationUnit))]
    public class OrganizationGetPagedOutput : EntityDto<long>
    {
        public string Code { get; set; }

        public long? ParentId { get; set; }

        public int? TenantId { get; set; }

        public ICollection<OrganizationGetPagedOutput> Children { get; set; }

        public string DisplayName { get; set; }
    }
}
