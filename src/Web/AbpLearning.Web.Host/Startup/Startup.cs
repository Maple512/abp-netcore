namespace AbpLearning.Web.Host.Startup
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Abp.AspNetCore;
    using Abp.AspNetCore.SignalR.Hubs;
    using Abp.Castle.Logging.Log4Net;
    using Abp.Extensions;
    using AbpLearning.Core.Identity;
    using Application;
    using Castle.Facilities.Logging;
    using Core;
    using Core.Configuration;
    using Filter;
    using LogDashboard;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Cors.Internal;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Logging;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerUI;

    public class Startup
    {
        private const string DefaultCorsPolicyName = "localhost";

        private readonly IConfigurationRoot _appConfiguration;

        private readonly IHostingEnvironment _environment;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();

            _environment = env;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new CorsAuthorizationFilterFactory(DefaultCorsPolicyName))
            );

            IdentityRegistrar.Register(services);

            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddSignalR();

            // Configure CORS for angular2 UI
            services.AddCors(
                options => options.AddPolicy(
                    DefaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            _appConfiguration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );

            // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "AbpLearning API",
                    Version = "v1",
                    TermsOfService = "https://github.com/Maple512/AbpLearning",
                });
                options.DocInclusionPredicate((docName, description) => true);

                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);

                var application = typeof(AbpLearningApplicationModule).Assembly.GetName().Name + ".xml";
                var applicationXmlPath = Path.Combine(basePath, application);

                options.IncludeXmlComments(applicationXmlPath);

                var webCore = typeof(AbpLearningWebCoreModule).Assembly.GetName().Name + ".xml";
                var webCoreXmlPath = Path.Combine(basePath, webCore);

                options.IncludeXmlComments(webCoreXmlPath);

                // Define the BearerAuth scheme that's in use
                options.AddSecurityDefinition("bearerAuth", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
            });

            // LogDashboard
            services.AddLogDashboard(opt =>
            {
                opt.RootPath = Path.Combine(_environment.ContentRootPath, @"App_Data/Logs");

                // Filter
                opt.AddAuthorizationFilter(new SamplesAuthorizationFilter());
            });

            // Configure Abp and Dependency Injection
            return services.AddAbp<AbpLearningWebHostModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAbp(options => { options.UseAbpRequestLocalization = false; }); // Initializes ABP framework.

            app.UseCors(DefaultCorsPolicyName); // Enable CORS!

            // add wwwroot path
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAbpRequestLocalization();

            // LogDashboard
            app.UseLogDashboard();

            app.UseSignalR(routes =>
            {
                routes.MapHub<AbpCommonHub>("/signalr");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable middleware to serve swagger - ui assets(HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AbpLearning API V1");
                //options.SwaggerEndpoint(_appConfiguration["App:ServerRootAddress"].EnsureEndsWith('/') + "swagger/v1/swagger.json", "AbpLearning API V1");

                options.DocExpansion(DocExpansion.None);

                options.EnableFilter();

                options.EnableDeepLinking();

                options.IndexStream = () => Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("AbpLearning.Web.Host.wwwroot.swagger.ui.index.html");
            }); // URL: /swagger
        }
    }
}
