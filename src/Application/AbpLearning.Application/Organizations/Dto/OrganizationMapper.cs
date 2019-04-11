namespace AbpLearning.Application.Organizations.Dto
{
    using Abp.Organizations;
    using AutoMapper;

    public class OrganizationMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<OrganizationUnit, OrganizationGetListDto>();
        }
    }
}
