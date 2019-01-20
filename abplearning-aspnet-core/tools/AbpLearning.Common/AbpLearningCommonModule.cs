namespace AbpLearning.Common
{
    using Abp.Modules;
    using Abp.Reflection.Extensions;

    public class AbpLearningCommonModule : AbpModule
    {
        public AbpLearningCommonModule()
        {
        }

        public override void Initialize()
        {
            var assembly = typeof(AbpLearningCommonModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(assembly);
        }

        public override void PostInitialize()
        {

        }

        public override void PreInitialize()
        {

        }
    }
}
