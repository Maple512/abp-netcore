namespace AbpLearning.Application
{
    using Abp.AutoMapper;
    using Abp.Modules;
    using Abp.Reflection.Extensions;
    using AbpLearning.Application.Authorization.Permissions.Dto;
    using AbpLearning.Application.Authorization.Roles.Dto;
    using AbpLearning.Application.Authorization.Users.Dto;
    using AbpLearning.Application.Organizations.Dto;
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
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                RoleMapper.CreateMappings(configuration);

                PermissionMapper.CreateMappings(configuration);

                UserMapper.CreateMappings(configuration);

                OrganizationMapper.CreateMappings(configuration);
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
