namespace AbpLearning.Core.CloudBookLists.BookLists.DomainService
{
    using Abp.Domain.Repositories;
    using Base;

    public class BookListDomainService : DomainServiceBase<BookList, long>, IBookListDomainService
    {
        public BookListDomainService(IRepository<BookList, long> repository) : base(repository)
        {

        }
    }
}
