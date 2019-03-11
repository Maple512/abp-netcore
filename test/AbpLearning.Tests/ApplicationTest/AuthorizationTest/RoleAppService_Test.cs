namespace AbpLearning.Tests.ApplicationTest.AuthorizationTest
{
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Authorization;
    using AbpLearning.Application.Authorization.Roles;
    using AbpLearning.Application.Authorization.Roles.Dto;
    using Xunit;

    public class RoleAppService_Test : AbpLearningTestBase
    {
        private readonly IRoleAppService _roleAppService;

        private readonly IPermissionManager _permissionManager;

        public RoleAppService_Test()
        {
            _roleAppService = Resolve<IRoleAppService>();
            _permissionManager = Resolve<IPermissionManager>();
        }

        [Theory(DisplayName = "get roles for view")]
        [InlineData("Pages.Authentication.Usewr")]
        public async Task GetAllForViewAsync_Test(string permissionName)
        {
            var roles = await _roleAppService.GetAllForViewAsync(new RoleGetViewInput() { PermissionName = permissionName });

            Assert.True(roles.Items.Count > 0);
        }

        [Theory(DisplayName = "create role")]
        [InlineData("TestRole1", "TestRole1_DisplayName", "1_discription", "Pages")]
        // [InlineData("TestRole4", "TestRole4_DisplayName", "4_discription", "NoPermissionName")]
        public async Task CreateAsync_Test(string name, string displayname, string description, params string[] grantedPerssionNames)
        {
            var permissionName = _permissionManager.GetAllPermissions().FirstOrDefault().Name;
            var roleInput = new RoleCreateInput()
            {
                Name = name,
                DisplayName = displayname,
                Description = description,
                GrantedPermissions = grantedPerssionNames?.ToList()
            };

            var result = await _roleAppService.CreateAsync(roleInput);

            Assert.True(result == null);
        }
    }
}
