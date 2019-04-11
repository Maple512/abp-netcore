using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore
{
    public static class AbpLearningDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpLearningDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpLearningDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
