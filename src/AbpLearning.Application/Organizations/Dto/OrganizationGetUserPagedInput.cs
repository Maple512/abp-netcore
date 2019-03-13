namespace AbpLearning.Application.Organizations.Dto
{
    using Base;

    public class OrganizationGetUserPagedInput : PagedFilteringDtoBase
    {
        public long OrganizationUnitId { get; set; }
    }
}
