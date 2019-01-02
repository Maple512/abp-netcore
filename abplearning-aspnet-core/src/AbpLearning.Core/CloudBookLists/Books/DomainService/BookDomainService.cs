namespace AbpLearning.Core.CloudBookLists.Books.DomainService
{
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Repositories;
    using Base;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// <see cref="Book"/> 领域服务
    /// </summary>
    public class BookDomainService : DomainServiceBase<Book, long>, IBookDomainService
    {
        public BookDomainService(IRepository<Book, long> bookRepository) : base(bookRepository)
        { }

        public override Task<Book> GetAsync(long id)
        {
            return GetAll().Where(m => m.Id == id).Include(m => m.Tags).FirstAsync();
        }
    }
}
