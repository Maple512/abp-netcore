namespace AbpLearning.Core.CloudBookLists
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Domain.Services;
    using BookLists;

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

        #endregion
    }
}
