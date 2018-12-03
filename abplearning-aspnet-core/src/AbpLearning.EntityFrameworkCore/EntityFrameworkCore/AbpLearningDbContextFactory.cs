using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AbpLearning.Configuration;
using AbpLearning.Web;

namespace AbpLearning.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AbpLearningDbContextFactory : IDesignTimeDbContextFactory<AbpLearningDbContext>
    {
        public AbpLearningDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpLearningDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AbpLearningDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AbpLearningConsts.ConnectionStringName));

            return new AbpLearningDbContext(builder.Options);
        }
    }
}
