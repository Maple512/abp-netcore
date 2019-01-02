namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore
{
    using Abp.Zero.EntityFrameworkCore;
    using Core;
    using Core.Authorization.Roles;
    using Core.Authorization.Users;
    using Core.CloudBookLists.BookLiseCells;
    using Core.CloudBookLists.BookLists;
    using Core.CloudBookLists.Books;
    using Core.CloudBookLists.BookTags;
    using Core.MultiTenancy;
    using Microsoft.EntityFrameworkCore;

    public class AbpLearningDbContext : AbpZeroDbContext<Tenant, Role, User, AbpLearningDbContext>
    {
        public AbpLearningDbContext(DbContextOptions<AbpLearningDbContext> options)
            : base(options)
        {
        }

        /* Define a DbSet for each entity of the application 依赖注入 */

        #region 云书单

        /// <summary>
        /// 书签
        /// </summary>
        public DbSet<BookTag> BookTag { get; set; }

        /// <summary>
        /// 书籍
        /// </summary>
        public DbSet<Book> Book { get; set; }

        /// <summary>
        /// 书单格子（1格子/书）
        /// </summary>
        public DbSet<BookListCell> BookListCell { get; set; }

        /// <summary>
        /// 书单
        /// </summary>
        public DbSet<BookList> BookList { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 清除Abp的默认表前缀
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("");

            base.OnModelCreating(modelBuilder);

            CloudBookListBuilder(modelBuilder);
        }

        private ModelBuilder CloudBookListBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookTag>()
                .ToTable(nameof(BookTag), AbpLearningConsts.SchemaNameForCloudBookList);

            modelBuilder.Entity<Book>()
                .ToTable(nameof(Book), AbpLearningConsts.SchemaNameForCloudBookList);

            modelBuilder.Entity<BookListCell>()
                .ToTable(nameof(BookListCell), AbpLearningConsts.SchemaNameForCloudBookList);

            modelBuilder.Entity<BookList>()
                .ToTable(nameof(BookList), AbpLearningConsts.SchemaNameForCloudBookList);

            return modelBuilder;
        }
    }
}
