namespace AbpLearning.Application.Organizations.Dto
{
    using Abp.AutoMapper;
    using Abp.Organizations;
    using Base;

    [AutoMapFrom(typeof(OrganizationUnit))]
    public class OrganizationGetViewOutput : INullIdEntityDto
    {
        public virtual long? ParentId { get; set; }

        public string Code { get; set; }

        public string DisplayName { get; set; }

        /// <summary>
        /// Number of organizational members
        /// </summary>
        public int MemberCount { get; set; }
    }
}
