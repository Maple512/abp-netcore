namespace AbpLearning.Core.CloudBookList.Book.DomainService
{
    using Abp.Domain.Repositories;
    using AbpLearning.Core.Base;

    /// <summary>
    /// <see cref="Book"/> 领域服务
    /// </summary>
    public class BookDomainService : DomainServiceBase<Book, long>, IBookDomainService
    {
        public BookDomainService(IRepository<Book, long> bookRepository) : base(bookRepository)
        {
        }
    }
}
