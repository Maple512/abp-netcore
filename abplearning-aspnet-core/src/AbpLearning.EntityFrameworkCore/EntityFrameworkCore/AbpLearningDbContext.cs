namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore
{
    using Abp.Zero.EntityFrameworkCore;
    using AbpLearning.Core.Authorization.Roles;
    using AbpLearning.Core.Authorization.Users;
    using AbpLearning.Core.CloudBookList.Book;
    using AbpLearning.Core.CloudBookList.BookLists;
    using AbpLearning.Core.CloudBookList.BookTags;
    using AbpLearning.Core.CloudBookList.Relationships;
    using AbpLearning.Core.MultiTenancy;
    using Microsoft.EntityFrameworkCore;

    public class AbpLearningDbContext : AbpZeroDbContext<Tenant, Role, User, AbpLearningDbContext>
    {
        public AbpLearningDbContext(DbContextOptions<AbpLearningDbContext> options)
            : base(options)
        {
        }

        /* Define a DbSet for each entity of the application 依赖注入 */

        #region 云书单

        public DbSet<BookTag> BookTag { get; set; }

        public DbSet<Book> Book { get; set; }

        public DbSet<BookList> BookList { get; set; }

        public DbSet<BookAndBookTagRelationship> BookAndBookTagRelationship { get; set; }

        public DbSet<BookListAndBookRelationship> BookListAndBookRelationship { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 清除Abp的默认表前缀
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("");

            base.OnModelCreating(modelBuilder);
        }
    }
}
