namespace AbpLearning.Application.Authorization.Users.Dto
{
    using AbpLearning.Core.Authorization.Users;
    using AutoMapper;

    public class UserMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<UserCreateInput, User>();
        }
    }
}
