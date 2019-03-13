namespace AbpLearning.Application.Organizations.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using Abp.Organizations;
    using Base;

    [AutoMapTo(typeof(OrganizationUnit))]
    public class OrganizationCreateInput : INullIdEntityDto
    {
        [Required]
        [StringLength(95)]
        public virtual string Code { get; set; }

        [Required]
        [StringLength(128)]
        public virtual string DisplayName { get; set; }

        public virtual long? ParentId { get; set; }

        public virtual int? TenantId { get; set; }
    }
}
