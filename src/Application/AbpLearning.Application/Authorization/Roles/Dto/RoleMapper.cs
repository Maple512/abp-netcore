namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using AbpLearning.Core.Authorization.Roles;
    using AutoMapper;

    public class RoleMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Role, RoleGetPagedOutput>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime));
        }
    }
}
