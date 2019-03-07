namespace AbpLearning.Application
{
    using Abp.AutoMapper;
    using Abp.Modules;
    using Abp.Reflection.Extensions;
    using CloudBookLists.Books.Model;
    using Core;
    using Core.Authorization;
    using Core.CloudBookLists.BookLists.Authorization;
    using Core.CloudBookLists.Books.Authorization;
    using Core.Files;

    [DependsOn(
        typeof(AbpLearningCoreModule),
        typeof(AbpAutoMapperModule))]
    public class AbpLearningApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpLearningAuthorizationProvider>();

            #region 云书单权限

            Configuration.Authorization.Providers.Add<BookAuthorizationProvider>();

            Configuration.Authorization.Providers.Add<BookListAuthorizationProvider>();

            #endregion

            #region File

            Configuration.Authorization.Providers.Add<FileAuthorizationProvider>();

            #endregion

            // 自定义类型映射
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                BookMapper.CreateMappings(configuration);
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
