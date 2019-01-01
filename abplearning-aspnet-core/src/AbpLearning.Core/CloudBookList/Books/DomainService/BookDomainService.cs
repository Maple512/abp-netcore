namespace AbpLearning.Core.CloudBookList.Books.DomainService
{
    using Abp.Domain.Repositories;
    using Base;

    /// <summary>
    /// <see cref="Book"/> 领域服务
    /// </summary>
    public class BookDomainService : DomainServiceBase<Books.Book, long>, IBookDomainService
    {
        public BookDomainService(IRepository<Book, long> bookRepository) : base(bookRepository)
        {
        }
    }
}
