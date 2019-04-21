namespace AbpLearning.Application.Authorization.Users.Dto
{
    using AbpLearning.Core.Authorization.Users;
    using AutoMapper;

    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<UserCreateInput, User>();
        }
    }
}
