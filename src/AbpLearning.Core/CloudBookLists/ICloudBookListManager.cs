namespace AbpLearning.Core.CloudBookLists
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Domain.Services;
    using BookLists;
    using Books;

    public interface ICloudBookListManager : IDomainService
    {
        #region Book

        /// <summary>
        /// 获取 书籍 所在的所有 书单
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<List<BookList>> GetBookListForBookAsync(long bookId);

        /// <summary>
        /// 删除书籍及相关de标签，书单格子
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task DeleteForBookAsync(long bookId);

        /// <summary>
        /// 批量删除 书籍
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task BatchDeleteForBookAsync(List<long> bookIds);

        #endregion

        #region BookList

        /// <summary>
        /// 获取书单引用的所有书籍
        /// </summary>
        /// <param name="bookListId"></param>
        /// <returns></returns>
        Task<List<Book>> GetBookForBookListAsync(long bookListId);

        /// <summary>
        /// 删除书单包括书单下所有格子
        /// </summary>
        /// <param name="bookListId"></param>
        /// <returns></returns>
        Task DeleteForBookListAsync(long bookListId);

        /// <summary>
        /// 批量删除书单，包括书单下所有格子
        /// </summary>
        /// <param name="bookListIds"></param>
        /// <returns></returns>
        Task BatchDeleteForBookListAsync(List<long> bookListIds);

        #endregion
    }
}
