namespace AbpLearning.Tests.ApplicationTest
{
    using System.Threading.Tasks;
    using Application.Authorization.Users;
    using Application.Authorization.Users.Dto;
    using Microsoft.EntityFrameworkCore;
    using Shouldly;
    using Xunit;

    public class UserAppService_Test : AbpLearningTestBase
    {
        private readonly IUserAppService userAppService;

        public UserAppService_Test()
        {
            userAppService = Resolve<IUserAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            var output = await userAppService.GetPagedAsync(new UserGetPagedInput { MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBeGreaterThanOrEqualTo(0);
        }

        [Theory]
        [InlineData("LiLing", "123456", "123@163.com")]
        public async Task CreateUser_Test(string userName, string password, string emailAddress)
        {
            // Act
            await userAppService.CreateAsync(
                new UserCreateInput
                {
                    EmailAddress = emailAddress,
                    IsActive = true,
                    Password = password,
                    UserName = userName
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "LiLing");
                johnNashUser.ShouldNotBeNull();
            });
        }
    }
}
