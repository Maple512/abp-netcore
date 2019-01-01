namespace AbpLearning.Core.CloudBookList.BookTags.DomainService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Repositories;
    using Base;

    public class BookTagDomainService : DomainServiceBase<BookTag, long>, IBookTagDomainService
    {
        public BookTagDomainService(IRepository<BookTag, long> bookRepository) : base(bookRepository)
        {
        }

        /// <summary>
        /// 获取书籍的所有Tag
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public List<BookTag> GetTagsByBookId(long bookId)
        {
            return GetAll().Where(m => m.BookId == bookId).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task DeleteTagForBookIdAsync(long bookId)
        {
            var bookTags = await _repository.GetAllListAsync(m => m.BookId == bookId);

            await BatchDeleteAsync(bookTags.Select(m => m.Id));
        }
    }
}
