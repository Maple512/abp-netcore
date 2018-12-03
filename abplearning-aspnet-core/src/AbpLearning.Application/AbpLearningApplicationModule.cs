using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpLearning.Authorization;

namespace AbpLearning
{
    [DependsOn(
        typeof(AbpLearningCoreModule),
        typeof(AbpAutoMapperModule))]
    public class AbpLearningApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpLearningAuthorizationProvider>();

            // 自定义类型映射
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                // XXXMapper.CreateMappers(configuration);


            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpLearningApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
