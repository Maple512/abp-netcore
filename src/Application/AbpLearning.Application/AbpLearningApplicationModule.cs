namespace AbpLearning.Application
{
    using Abp.AutoMapper;
    using Abp.Modules;
    using Abp.Reflection.Extensions;
    using Core;
    using Core.Authorization;

    [DependsOn(
        typeof(AbpLearningCoreModule),
        typeof(AbpAutoMapperModule))]
    public class AbpLearningApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            // Pages
            Configuration.Authorization.Providers.Add<AbpLearningAuthorizationProvider>();

            // 自定义类型映射
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration => { });
        }

        public override void Initialize()
        {
            var assembly = typeof(AbpLearningApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(assembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(assembly)
            );
        }
    }
}
