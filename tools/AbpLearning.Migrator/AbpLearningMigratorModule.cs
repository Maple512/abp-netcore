namespace AbpLearning.Migrator
{
    using Abp.Events.Bus;
    using Abp.Modules;
    using Abp.Reflection.Extensions;
    using AbpLearning.Core;
    using AbpLearning.Core.Configuration;
    using AbpLearning.EntityFrameworkCore.EntityFrameworkCore;
    using AbpLearning.Migrator.DependencyInjection;
    using Castle.MicroKernel.Registration;
    using Microsoft.Extensions.Configuration;

    [DependsOn(typeof(AbpLearningEntityFrameworkModule))]
    public class AbpLearningMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpLearningMigratorModule(AbpLearningEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(AbpLearningMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AbpLearningCoreConfig.CONNECTION_STRING_NAME
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpLearningMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
