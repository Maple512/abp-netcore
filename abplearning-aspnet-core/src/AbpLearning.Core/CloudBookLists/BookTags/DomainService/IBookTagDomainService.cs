namespace AbpLearning.Core.CloudBookLists.BookTags.DomainService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Base;

    /// <summary>
    /// <see cref="BookTag"/> 领域服务接口
    /// </summary>
    public interface IBookTagDomainService : IDomainServiceBase<BookTag, long>
    {
        /// <summary>
        /// 获取书籍的所有标签
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<List<BookTag>> GetForBookAsync(long bookId);

        /// <summary>
        /// 删除书籍的所有标签
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task BatchDeleteForBookAsync(long bookId);
    }
}
