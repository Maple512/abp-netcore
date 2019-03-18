namespace AbpLearning.Application.Organizations.Dto
{
    using Base;

    /// <summary>
    /// Defines the <see cref="OrganizationUserGetPagedInput" />
    /// </summary>
    public class OrganizationUserGetPagedInput : PagedFilteringDtoBase
    {
        /// <summary>
        /// Gets or sets the OrganizationId
        /// </summary>
        public long OrganizationId { get; set; }
    }
}
