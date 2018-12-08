namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore.EntityConfigurations.CloudBookList
{
    using AbpLearning.Core.CloudBookList.Books;
    using Microsoft.EntityFrameworkCore;

    internal class BookConfiguration : IEntityTypeConfiguration
    {
        public BookConfiguration(ModelBuilder builder)
        {
            builder.Entity<Book>();
        }
    }
}
