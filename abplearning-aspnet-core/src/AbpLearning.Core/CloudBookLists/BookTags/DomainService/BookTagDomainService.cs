namespace AbpLearning.Core.CloudBookLists.BookTags.DomainService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Repositories;
    using Base;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// <see cref="BookTag"/> 领域服务
    /// </summary>
    public class BookTagDomainService : DomainServiceBase<BookTag, long>, IBookTagDomainService
    {
        public BookTagDomainService(IRepository<BookTag, long> bookRepository) : base(bookRepository)
        {
        }

        /// <summary>
        /// 书签 获取书籍的所有书签
        /// </summary>
        /// <param name="bookId">书籍</param>
        /// <returns></returns>
        public async Task<List<BookTag>> GetForBookAsync(long bookId)
        {
            return await GetAll().Where(m => m.BookId == bookId).ToListAsync();
        }

        /// <summary>
        /// 书签 删除书籍的所有书签
        /// </summary>
        /// <param name="bookId">书籍</param>
        /// <returns></returns>
        public async Task BatchDeleteForBookAsync(long bookId)
        {
            var bookTags = await _repository.GetAllListAsync(m => m.BookId == bookId);

            if (bookTags.Count > 0)
            {
                await BatchDeleteAsync(bookTags.Select(m => m.Id));
            }
        }

        /// <summary>
        /// 书签 删除多个书籍拥有的书签
        /// </summary>
        /// <param name="bookIds">书籍</param>
        /// <returns></returns>
        public async Task BatchDeleteForBookAsync(List<long> bookIds)
        {
            var bookTags = await _repository.GetAllListAsync(m => bookIds.Contains(m.Id));

            if (bookTags.Count > 0)
            {
                await BatchDeleteAsync(bookTags.Select(m => m.Id));
            }
        }
    }
}
