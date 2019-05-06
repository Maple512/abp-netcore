using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore
{
    public static class AbpLearningDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpLearningDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpLearningDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
