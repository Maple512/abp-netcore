namespace AbpLearning.Application
{
    using Abp.AutoMapper;
    using Abp.Modules;
    using Abp.Reflection.Extensions;
    using AbpLearning.Core.Authorization;
    using AbpLearning.Core.CloudBookList.Books.Authorization;
    using AbpLearning.Core.CloudBookList.BookLists.Authorization;
    using AbpLearning.Core.CloudBookList.BookTags.Authorization;
    using Core;

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

            Configuration.Authorization.Providers.Add<BookTagAuthorizationProvider>();

            Configuration.Authorization.Providers.Add<BookListAuthorizationProvider>();

            #endregion

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
