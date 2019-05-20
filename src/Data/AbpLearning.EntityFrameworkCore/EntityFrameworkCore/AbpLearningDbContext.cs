namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore
{
    using Abp.Zero.EntityFrameworkCore;
    using Core.Authorization.Roles;
    using Core.Authorization.Users;
    using Core.MultiTenancy;
    using Microsoft.EntityFrameworkCore;

    public class AbpLearningDbContext : AbpZeroDbContext<Tenant, Role, User, AbpLearningDbContext>
    {
        public AbpLearningDbContext(DbContextOptions<AbpLearningDbContext> options)
            : base(options)
        {
        }

        /* Define a DbSet for each entity of the application 依赖注入 */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 如果使用Mysql数据库，本地连接可以，但发布生产后，链接失败：这里需要注释掉，
            // Unable to connect to any of the specified MySQL hosts.
            // 清除Abp的默认表前缀 
            // modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("", "Abp");

            base.OnModelCreating(modelBuilder);
        }
    }
}
