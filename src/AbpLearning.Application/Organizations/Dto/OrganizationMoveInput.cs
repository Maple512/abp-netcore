namespace AbpLearning.Application.Organizations.Dto
{
    /// <summary>
    /// Defines the <see cref="OrganizationMoveInput" />
    /// </summary>
    public class OrganizationMoveInput
    {
        /// <summary>
        /// Gets or sets the OrganizationId
        /// </summary>
        public long OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets the OrganizationNewId
        /// </summary>
        public long? OrganizationParentId { get; set; }
    }
}
