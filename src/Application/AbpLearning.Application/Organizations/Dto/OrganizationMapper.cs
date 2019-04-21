namespace AbpLearning.Application.Organizations.Dto
{
    using Abp.Organizations;
    using AutoMapper;

    public class OrganizationMapper: Profile
    {
        public OrganizationMapper()
        {
            CreateMap<OrganizationUnit, OrganizationGetListDto>();
        }
    }
}
