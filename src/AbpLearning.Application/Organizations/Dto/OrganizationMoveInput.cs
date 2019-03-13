namespace AbpLearning.Application.Organizations.Dto
{
    using Abp.Application.Services.Dto;

    public class OrganizationMoveInput : EntityDto<long>
    {
        /// <summary>
        /// a new parent node id
        /// </summary>
        public long? NewParentId { get; set; }
    }
}
