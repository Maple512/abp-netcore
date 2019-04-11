namespace AbpLearning.Application.Organizations.Dto
{
    using System;
    using System.Collections.Generic;
    using Abp.Authorization.Users;
    using Abp.AutoMapper;
    using Abp.Domain.Entities.Auditing;

    /// <summary>
    /// Defines the <see cref="OrganizationUserGetPagedOutput" />
    /// </summary>
    [AutoMapFrom(typeof(UserOrganizationUnit))]
    public class OrganizationUserGetPagedOutput : IHasCreationTime
    {
        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the OrganizationId
        /// </summary>
        public List<string> OrganizationNames { get; set; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the CreationTime
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
