namespace AbpLearning.Application.MultiTenancy
{
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.IdentityFramework;
    using Abp.MultiTenancy;
    using Abp.Runtime.Security;
    using AbpLearning.Application.Base;
    using AbpLearning.Application.MultiTenancy.Dto;
    using AbpLearning.Core;
    using AbpLearning.Core.Authorization.Roles;
    using AbpLearning.Core.Authorization.Users;
    using AbpLearning.Core.Editions;
    using AbpLearning.Core.MultiTenancy;
    using AbpLearning.MultiTenancy.Dto;
    using Microsoft.AspNetCore.Identity;

    [AbpAuthorize(AbpLearningPermissions.Tenant)]
    public class TenantAppService : CrudAsyncAppService<Tenant, int, TenantGetViewOutput, TenantGetPagedOutput, PagedFilteringModelBase, TenantGetUpdateOutput, TenantCreateInput, TenantUpdateInput>, ITenantAppService
    {
        private readonly TenantManager _tenantManager;
        private readonly EditionManager _editionManager;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IAbpZeroDbMigrator _abpZeroDbMigrator;
        private readonly IPasswordHasher<User> _passwordHasher;

        public TenantAppService(
            IRepository<Tenant, int> repository,
            TenantManager tenantManager,
            EditionManager editionManager,
            UserManager userManager,
            RoleManager roleManager,
            IAbpZeroDbMigrator abpZeroDbMigrator,
            IPasswordHasher<User> passwordHasher)
            : base(repository)
        {
            _tenantManager = tenantManager;
            _editionManager = editionManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _abpZeroDbMigrator = abpZeroDbMigrator;
            _passwordHasher = passwordHasher;
        }

        public override async Task<EntityDto<int>> CreateAsync(TenantCreateInput input)
        {
            CheckCreatePermission();

            var tenant = ObjectMapper.Map<Tenant>(input);
            tenant.ConnectionString = input.ConnectionString.IsNullOrEmpty()
                ? null
                : SimpleStringCipher.Instance.Encrypt(input.ConnectionString);

            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }

            //To get new tenant's id.
            await _tenantManager.CreateAsync(tenant);
            await CurrentUnitOfWork.SaveChangesAsync();


            // Create tenant Database
            _abpZeroDbMigrator.CreateOrMigrateForTenant(tenant);

            // We are working entities of new tenant, so changing tenant filter
            using (CurrentUnitOfWork.SetTenantId(tenant.Id))
            {
                // Create static roles for new tenant
                CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));

                // To get static role ids
                await CurrentUnitOfWork.SaveChangesAsync(); 

                //    grant all permissions to admin role
                var adminRole = _roleManager.Roles.Single(r => r.Name == StaticRoleNames.Tenants.Admin);
                await _roleManager.GrantAllPermissionsAsync(adminRole);

                // Create admin user for the tenant
                var adminUser = User.CreateTenantAdminUser(tenant.Id, input.AdminEmailAddress);
                adminUser.Password = _passwordHasher.HashPassword(adminUser, User.DefaultPassword);
                CheckErrors(await _userManager.CreateAsync(adminUser));
                await CurrentUnitOfWork.SaveChangesAsync(); // To get admin user's id


                CheckErrors(await _userManager.AddToRoleAsync(adminUser, adminRole.Name));
                await CurrentUnitOfWork.SaveChangesAsync();
            }
            return ObjectMapper.Map<EntityDto>(tenant);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            var tenant = await _tenantManager.GetByIdAsync(input.Id);
            await _tenantManager.DeleteAsync(tenant);
        }

        private void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
