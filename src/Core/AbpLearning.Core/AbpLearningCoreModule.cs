namespace AbpLearning.Core
{
    using Abp.Modules;
    using Abp.Reflection.Extensions;
    using Abp.Timing;
    using Abp.Zero;
    using Abp.Zero.Configuration;
    using AbpLearning.Core.Authorization.Roles;
    using AbpLearning.Core.Authorization.Users;
    using AbpLearning.Core.Configuration;
    using AbpLearning.Core.Localization;
    using AbpLearning.Core.MultiTenancy;
    using AbpLearning.Core.Timing;

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

            AbpLearningLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = AbpLearningCoreConfig.MULTI_TENANCY_ENABLED;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpLearningCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
