namespace AbpLearning.Core.CloudBookLists.BookLiseCells.DomainService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Base;

    /// <summary>
    /// <see cref="BookListCell"/> 领域服务接口
    /// </summary>
    public interface IBookListCellDomainService : IDomainServiceBase<BookListCell, long>
    {
        /// <summary>
        /// 获取书籍的所有格子
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<List<BookListCell>> GetForBookAsync(long bookId);

        /// <summary>
        /// 获取多个书籍的所有格子
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task<List<BookListCell>> GetForBookAsync(List<long> bookIds);

        /// <summary>
        /// 删除书籍的所有格子
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task BatchDeleteForBookAsync(long bookId);

        /// <summary>
        /// 删除多个书籍的所有格子
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task BatchDeleteForBookAsync(List<long> bookIds);
    }
}
