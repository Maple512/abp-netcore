namespace AbpLearning.Application.Organizations.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;

    /// <summary>
    /// Defines the <see cref="OrganizationUpdateInput" />
    /// </summary>
    public class OrganizationUpdateInput : EntityDto<long>
    {
        /// <summary>
        /// Gets or sets the ParentId
        /// </summary>
        public virtual long? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the DisplayName
        /// </summary>
        [Required]
        [StringLength(128)]
        public virtual string DisplayName { get; set; }
    }
}
