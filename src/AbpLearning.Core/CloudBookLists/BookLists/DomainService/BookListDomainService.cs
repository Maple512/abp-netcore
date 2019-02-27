namespace AbpLearning.Core.CloudBookLists.BookLists.DomainService
{
    using System.Threading.Tasks;
    using Abp.Domain.Repositories;
    using Base;

    public class BookListDomainService : DomainServiceBase<BookList, long>, IBookListDomainService
    {
        public BookListDomainService(IRepository<BookList, long> bookRepository) : base(bookRepository)
        {
           
        }
    }
}
