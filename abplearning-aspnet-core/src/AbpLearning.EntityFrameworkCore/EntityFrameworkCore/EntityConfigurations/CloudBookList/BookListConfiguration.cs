namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore.EntityConfigurations.CloudBookList
{
    using AbpLearning.Core.CloudBookList.BookLists;
    using Microsoft.EntityFrameworkCore;

    internal class BookListConfiguration : IEntityTypeConfiguration
    {
        public BookListConfiguration(ModelBuilder builder)
        {
            builder.Entity<BookList>();
        }
    }
}
