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

        /// <summary>
        /// 删除书籍时，删除格子
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task DeletedForBook(long bookId)
        {
            await _repository.DeleteAsync(m => m.BookId == bookId);
        }

        public async Task BatchDeleteForBooks(IEnumerable<long> bookIds)
        {
            var entities = _repository.GetAll().Where(m => bookIds.Contains(m.BookId));
            var ids = entities.Select(m => m.BookId);
            foreach (var id in ids)
            {
                await _repository.DeleteAsync(m => m.BookId == id);
            }
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

        public async Task BatchCreateAsync(IEnumerable<BookListCell> cells)
        {
            foreach (var cell in cells)
            {
                await _repository.InsertOrUpdateAsync(cell);
            }
        }

    }
}
