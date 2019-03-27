namespace AbpLearning.Application.Organizations.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="OrganizationUserInput" />
    /// </summary>
    public class OrganizationUserInput
    {
        /// <summary>
        /// Gets or sets the UserIds
        /// </summary>
        public List<long> UserIds { get; set; }

        /// <summary>
        /// Gets or sets the OrganizationId
        /// </summary>
        [Range(1, long.MaxValue)]
        public long OrganizationId { get; set; }
    }
}
