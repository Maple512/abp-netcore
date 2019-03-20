namespace AbpLearning.Application.Organizations.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Abp.Organizations;

    [AutoMapFrom(typeof(OrganizationUnit))]
    public class OrganizationGetUpdateOutput : EntityDto<long>
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
    }
}
