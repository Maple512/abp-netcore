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
        public BookDomainService(IRepository<Book, long> repository) : base(repository)
        { }

        /// <summary>
        /// 获取书籍（包括对应的书签）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task<Book> GetAsync(long id)
        {
            return GetAll().Where(m => m.Id == id).Include(m => m.Tags).FirstOrDefaultAsync();
        }
    }
}
