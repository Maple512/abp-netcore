namespace AbpLearning.Core.CloudBookLists.BookListCells.DomainService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Base;

    /// <inheritdoc />
    /// <summary>
    /// <see cref="BookListCell" /> 领域服务接口
    /// </summary>
    public interface IBookListCellDomainService : IDomainServiceBase<BookListCell, long>
    {
        #region Book

        /// <summary>
        /// 获取书籍的所有格子
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<List<BookListCell>> GetForBookAsync(long bookId);

        #endregion

        #region BookList

        /// <summary>
        /// 获取书单的所有格子
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<List<BookListCell>> GetForBookListAsync(long bookListId);

        /// <summary>
        /// 获取多个书单的所有格子
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task<List<BookListCell>> GetForBookListAsync(List<long> bookListIds);

        /// <summary>
        /// 删除书单的所有格子
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task BatchDeleteForBookListAsync(long bookListId);

        /// <summary>
        /// 删除多个书单的所有格子
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task BatchDeleteForBookListAsync(List<long> bookListIds);

        #endregion
    }
}
