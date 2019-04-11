using AbpLearning.Core;
using AbpLearning.Core.Configuration;
using AbpLearning.Core.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AbpLearningDbContextFactory : IDesignTimeDbContextFactory<AbpLearningDbContext>
    {
        public AbpLearningDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpLearningDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AbpLearningDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AbpLearningCoreConfig.CONNECTION_STRING_NAME));

            return new AbpLearningDbContext(builder.Options);
        }
    }
}
