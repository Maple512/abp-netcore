namespace AbpLearning.EntityFrameworkCore.EntityFrameworkCore.EntityConfigurations.CloudBookList
{
    using AbpLearning.Core.CloudBookList.Relationships;
    using Microsoft.EntityFrameworkCore;

    internal class BookListAndBookRelationshipConfiguration : IEntityTypeConfiguration
    {
        public BookListAndBookRelationshipConfiguration(ModelBuilder builder)
        {
            builder.Entity<BookListAndBookRelationship>();
        }
    }
}
