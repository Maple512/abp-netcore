namespace AbpLearning.Application.Organizations.Dto
{
    using Abp.Application.Services.Dto;

    /// <summary>
    /// Defines the <see cref="OrganizationGetTreeOutput" />
    /// </summary>
    public class OrganizationGetTreeOutput : EntityDto<long>
    {
        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the ParentId
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the DisplayName
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the MemberCount
        /// </summary>
        public int MemberCount { get; set; }
    }
}
