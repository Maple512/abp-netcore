using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpLearning.Configuration;

namespace AbpLearning.Web.Host.Startup
{
    [DependsOn(
       typeof(AbpLearningWebCoreModule))]
    public class AbpLearningWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpLearningWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpLearningWebHostModule).GetAssembly());
        }
    }
}
