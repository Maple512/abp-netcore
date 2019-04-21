namespace AbpLearning.Core
{
    using Abp.Configuration;
    using Abp.Modules;
    using Abp.Reflection.Extensions;
    using Abp.Timing;
    using Abp.Zero;
    using Abp.Zero.Configuration;
    using Authorization.Roles;
    using Authorization.Users;
    using Configuration.ApplicationScopes;
    using Localization;
    using MultiTenancy;
    using Timing;

    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AbpLearningCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            // Localization
            AbpLearningLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = AbpLearningCoreConfig.MULTI_TENANCY_ENABLED;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<ApplicationSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpLearningCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;

            var settings = IocManager.Resolve<ISettingDefinitionManager>().GetAllSettingDefinitions();
        }
    }
}
