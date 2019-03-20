namespace AbpLearning.Tests.ApplicationTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    using Shouldly;
    using Application.Organizations;
    using Application.Organizations.Dto;
    using Microsoft.EntityFrameworkCore;

    public class OrganizationAppService_Test : AbpLearningTestBase
    {
        private readonly IOrganizationAppService _organizationAppService;

        public OrganizationAppService_Test()
        {
            _organizationAppService = Resolve<IOrganizationAppService>();
        }

        [Theory]
        [InlineData("Master1")]
        [InlineData("Master2")]
        [InlineData("Master3")]
        public async Task CreateAsync_Test(string displayName, long? parent = null, int? tenant = null, string code = null)
        {
            var input = new OrganizationCreateInput()
            {
                DisplayName = displayName,
                Code = code,
                ParentId = parent,
                TenantId = tenant
            };

            await _organizationAppService.CreateAsync(input);

            await UsingDbContextAsync(async context =>
            {
                var organization = await context.OrganizationUnits.FirstOrDefaultAsync(ou => ou.DisplayName == displayName);
                organization.ShouldNotBeNull();
            });
        }
    }
}
