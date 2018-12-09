namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore
{
    using Abp.Zero.EntityFrameworkCore;
    using Core.Authorization.Roles;
    using Core.Authorization.Users;
    using Core.CloudBookList.BookLists;
    using Core.CloudBookList.Books;
    using Core.CloudBookList.BookTags;
    using Core.CloudBookList.Relationships;
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

            base.OnModelCreating(modelBuilder);

            // 书籍和书籍标签
            modelBuilder.Entity<BookAndBookTagRelationship>()
                .HasOne(o => o.Book)
                .WithMany(o => o.BookAndBookTagRelationships)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BookAndBookTagRelationship>()
                .HasOne(o => o.BookTag)
                .WithMany(o => o.BookAndBookTagRelationships)
                .HasForeignKey(e => e.BookTagId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // 书单和书籍
            modelBuilder.Entity<BookListAndBookRelationship>()
                .HasOne(o => o.BookList)
                .WithMany(o => o.BookListAndBookRelationships)
                .HasForeignKey(e => e.BookListId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BookListAndBookRelationship>()
                .HasOne(o => o.Book)
                .WithMany(o => o.BookListAndBookRelationships)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
