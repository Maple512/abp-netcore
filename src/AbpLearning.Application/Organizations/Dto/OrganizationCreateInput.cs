namespace AbpLearning.Application.Organizations.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using Abp.Organizations;
    using Base;

    /// <summary>
    /// Defines the <see cref="OrganizationCreateInput" />
    /// </summary>
    [AutoMapTo(typeof(OrganizationUnit))]
    public class OrganizationCreateInput : INullIdEntityDto
    {
        /// <summary>
        /// Gets or sets the ParentId
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the TenantId
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// Gets or sets the DisplayName
        /// </summary>
        [Required]
        [StringLength(128)]
        public string DisplayName { get; set; }
    }
}
