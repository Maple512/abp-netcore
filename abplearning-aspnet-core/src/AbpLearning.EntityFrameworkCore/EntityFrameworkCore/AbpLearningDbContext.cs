
namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore
{
    using Abp.Zero.EntityFrameworkCore;
    using Core.CloudBookList.Books;
    using Core.Authorization.Roles;
    using Core.Authorization.Users;
    using Core.CloudBookList.BookLists;
    using Core.CloudBookList.BookTags;
    using Core.CloudBookList.Relationships;
    using Core.MultiTenancy;
    using EntityConfigurations;
    using Microsoft.EntityFrameworkCore;

    public class AbpLearningDbContext : AbpZeroDbContext<Tenant, Role, User, AbpLearningDbContext>
    {
        public AbpLearningDbContext(DbContextOptions<AbpLearningDbContext> options)
            : base(options)
        {
        }

        /* Define a DbSet for each entity of the application 依赖注入 */

        #region 云书单

        public DbSet<Book> Book { get; set; }

        public DbSet<BookTag> BookTag { get; set; }

        public DbSet<BookList> BookList { get; set; }

        public DbSet<BookAndBookTagRelationship> BookAndBookTagRelationship { get; set; }

        public DbSet<BookListAndBookRelationship> BookListAndBookRelationship { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 清除Abp的默认表前缀
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("");

            modelBuilder.ExecuteConfigurations("Abplearning.Core");

            base.OnModelCreating(modelBuilder);
        }
    }
}
