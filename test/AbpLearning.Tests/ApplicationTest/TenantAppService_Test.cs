namespace AbpLearning.Tests.ApplicationTest
{
    using System.Threading.Tasks;
    using AbpLearning.Application.MultiTenancy;
    using AbpLearning.Application.MultiTenancy.Dto;
    using Shouldly;
    using Xunit;

    public class TenantAppService_Test : AbpLearningTestBase
    {
        private readonly ITenantAppService tenantAppService;

        public TenantAppService_Test()
        {
            tenantAppService = Resolve<ITenantAppService>();
        }

        [Theory]
        [InlineData("Maple512", "TestTenant1", "123@456.com", "", true)]
        public async Task CreateAsync_Test(string tenancyName, string name, string adminEmailAddress, string connectionString, bool isActive)
        {
            LoginAsHost("admin");

            var createInput = new TenantCreateInput()
            {
                Name = name,
                ConnectionString = connectionString,
                TenancyName = tenancyName,
                AdminEmailAddress = adminEmailAddress,
                IsActive = isActive
            };

            var result = await tenantAppService.CreateAsync(createInput);

            result.ShouldBeNull();

            Assert.True(result == null);
        }
    }
}
