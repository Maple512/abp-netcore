namespace AbpLearning.Web.Core
{
    using System;
    using System.IO;
    using System.Text;
    using Abp.AspNetCore;
    using Abp.AspNetCore.Configuration;
    using Abp.AspNetCore.SignalR;
    using Abp.Configuration.Startup;
    using Abp.Modules;
    using Abp.Reflection.Extensions;
    using Abp.Zero.Configuration;
    using AbpLearning.Application;
    using AbpLearning.Common;
    using AbpLearning.Core;
    using AbpLearning.Core.Files.Folders;
    using AbpLearning.EntityFrameworkCore.EntityFrameworkCore;
    using AbpLearning.Web.Core.Authentication.JwtBearer;
    using AbpLearning.Web.Core.Configuration;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Abp.IO;
    using Microsoft.AspNetCore.Http;

    [DependsOn(
         typeof(AbpLearningApplicationModule),
         typeof(AbpLearningEntityFrameworkModule),
         typeof(AbpAspNetCoreModule),
         typeof(AbpLearningCommonModule)
        , typeof(AbpAspNetCoreSignalRModule)
     )]
    public class AbpLearningWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpLearningWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AbpLearningConsts.ConnectionStringName
            );

            Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true;

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(AbpLearningApplicationModule).GetAssembly()
                 );

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpLearningWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            SetAppFolderConfig();
        }

        /// <summary>
        /// 设置APP文件路径配置
        /// </summary>
        private void SetAppFolderConfig()
        {
            var appFolderConfig = IocManager.Resolve<AppFolderConfig>();

            appFolderConfig.WebURL = _appConfiguration["APP:ServerRootAddress"];
            appFolderConfig.WebRootPath = _env.WebRootPath;

            appFolderConfig.UploadFileFolder = Path.Combine(_env.WebRootPath, _appConfiguration["FilePath:Upload"]);
            appFolderConfig.UploadUserPortrait = Path.Combine(_env.WebRootPath, _appConfiguration["FilePath:UserProtrait"]);

            DirectoryHelper.CreateIfNotExists(appFolderConfig.UploadFileFolder);
            DirectoryHelper.CreateIfNotExists(appFolderConfig.UploadUserPortrait);
        }
    }
}
