namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore.EntityConfigurations.CloudBookList
{
    using AbpLearning.Core.CloudBookList.BookTags;
    using Microsoft.EntityFrameworkCore;

    internal class BookTagConfiguration : IEntityTypeConfiguration
    {
        public BookTagConfiguration(ModelBuilder builder)
        {
            builder.Entity<BookTag>();
        }
    }
}
