namespace AbpLearning.Core.CloudBookList.BookTags.DomainService
{
    using Abp.Domain.Repositories;
    using Base;

    public class BookTagDomainService : DomainServiceBase<BookTag, long>, IBookTagDomainService
    {
        public BookTagDomainService(IRepository<BookTag, long> bookRepository) : base(bookRepository)
        {
        }
    }
}
