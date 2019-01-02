namespace AbpLearning.Core.CloudBookLists.BookTags.DomainService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Repositories;
    using Base;
    using Microsoft.EntityFrameworkCore;

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
        public async Task<List<BookTag>> GetForBookAsync(long bookId)
        {
            return await GetAll().Where(m => m.BookId == bookId).ToListAsync();
        }

        /// <summary>
        /// 删除书籍的所有Tag
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task BatchDeleteForBookAsync(long bookId)
        {
            var bookTags = await _repository.GetAllListAsync(m => m.BookId == bookId);

            if(bookTags.Count > 0)
            {
                await BatchDeleteAsync(bookTags.Select(m => m.Id));
            }
        }
    }
}
