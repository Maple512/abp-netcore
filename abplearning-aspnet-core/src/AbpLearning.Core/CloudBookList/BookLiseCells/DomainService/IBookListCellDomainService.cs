namespace AbpLearning.Core.CloudBookList.BookLiseCells.DomainService
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
        /// 根据BookId获取单个格子
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<BookListCell> GetForBookAsync(long bookId);

        /// <summary>
        /// 根据BookIds获取多个格子
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task<IEnumerable<BookListCell>> GetForBookAsnyc(IEnumerable<long> bookIds);

        Task DeleteForBookAsync(long bookId);

        Task BatchDeleteForBookAsync(IEnumerable<long> bookIds);
    }
}
