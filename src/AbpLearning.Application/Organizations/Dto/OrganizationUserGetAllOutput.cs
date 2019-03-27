namespace AbpLearning.Application.Organizations.Dto
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="OrganizationUserGetAllOutput" />
    /// </summary>
    public class OrganizationUserGetAllOutput
    {
        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the OrganizationNames
        /// </summary>
        public List<string> OrganizationNames { get; set; } = new List<string>();
    }
}
