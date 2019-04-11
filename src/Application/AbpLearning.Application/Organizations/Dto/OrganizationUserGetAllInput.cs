namespace AbpLearning.Application.Organizations.Dto
{
    using Abp.Extensions;
    using Base;

    public class OrganizationUserGetAllInput : PagedFilteringDtoBase
    {
        public override void Normalize()
        {
            if (Sorting.IsNullOrEmpty())
            {
                Sorting = "UserName DESC";
            }
        }
    }
}
