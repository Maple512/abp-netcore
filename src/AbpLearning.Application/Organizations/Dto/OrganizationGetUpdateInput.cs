namespace AbpLearning.Application.Organizations.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;

    /// <summary>
    /// Defines the <see cref="OrganizationGetUpdateInput" />
    /// </summary>
    public class OrganizationGetUpdateInput : EntityDto<long>
    {
        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        [Required]
        [StringLength(95)]
        public virtual string Code { get; set; }

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
