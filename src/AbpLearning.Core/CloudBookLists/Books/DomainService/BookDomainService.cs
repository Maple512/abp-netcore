namespace AbpLearning.Core.CloudBookLists.Books.DomainService
{
    using Abp.Domain.Repositories;
    using Base;

    /// <summary>
    /// <see cref="Book"/> 领域服务
    /// </summary>
    public class BookDomainService : DomainServiceBase<Book, long>, IBookDomainService
    {
        public BookDomainService(IRepository<Book, long> repository) : base(repository)
        { }
    }
}
