namespace AbpLearning.Core.CloudBookLists.BookListCells.DomainService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Repositories;
    using Base;

    public class BookListCellDomainService : DomainServiceBase<BookListCell, long>, IBookListCellDomainService
    {
        public BookListCellDomainService(
            IRepository<BookListCell, long> repository)
            : base(repository)
        {
        }

        #region Book

        /// <summary>
        /// 书单格子 获取书籍对应的所有格子
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<List<BookListCell>> GetForBookAsync(long bookId)
        {
            return await _repository.GetAllListAsync(m => m.BookId == bookId);
        }

        #endregion

        #region BookList

        /// <summary>
        /// 书单格子 获取书单下的所有格子
        /// </summary>
        /// <param name="bookListId"></param>
        /// <returns></returns>
        public async Task<List<BookListCell>> GetForBookListAsync(long bookListId)
        {
            return await _repository.GetAllListAsync(m => m.BookListId == bookListId);
        }

        /// <summary>
        /// 书单格子 获取多个书单下的所有格子
        /// </summary>
        /// <param name="bookListIds"></param>
        /// <returns></returns>
        public async Task<List<BookListCell>> GetForBookListAsync(List<long> bookListIds)
        {
            return await _repository.GetAllListAsync(m => bookListIds.Contains(m.BookListId));
        }

        /// <summary>
        /// 书单格子 删除书单时，删除所有格子
        /// </summary>
        /// <param name="bookListId"></param>
        /// <returns></returns>
        public async Task BatchDeleteForBookListAsync(long bookListId)
        {
            var entities = await GetForBookListAsync(bookListId);

            if (entities.Count > 0)
            {
                await BatchDeleteAsync(entities.Select(m => m.Id));
            }
        }

        /// <summary>
        /// 书单格子 批量删除书单时，删除所有格子
        /// </summary>
        /// <param name="bookListIds"></param>
        /// <returns></returns>
        public async Task BatchDeleteForBookListAsync(List<long> bookListIds)
        {
            var entities = await GetForBookListAsync(bookListIds);

            if (entities.Count > 0)
            {
                await BatchDeleteAsync(entities.Select(m => m.Id));
            }
        }

        #endregion
    }
}
