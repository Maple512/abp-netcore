using System.Threading.Tasks;

namespace AbpLearning.Core.CloudBookList.BookTags.DomainService
{
    using System.Collections.Generic;
    using Base;

    /// <summary>
    /// <see cref="BookTag"/> 领域服务接口
    /// </summary>
    public interface IBookTagDomainService : IDomainServiceBase<BookTag, long>
    {
        /// <summary>
        /// 获取书籍的所有Tag
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        List<BookTag> GetTagsByBookId(long bookId);

        /// <summary>
        /// 删除书籍所有的标签
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task DeleteTagForBookIdAsync(long bookId);
    }
}
