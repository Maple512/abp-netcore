namespace AbpLearning.Core.CloudBookList.Relationships.DomainService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Domain.Services;

    public interface IBookAndBookTagRelationshipDomainService : IDomainService
    {
        /// <summary>
        /// 根据Book.Id查询关联数据
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<IEnumerable<BookAndBookTagRelationship>> GetByBookIdAsync(long bookId);

        /// <summary>
        /// 根据BookTag.Id查询关联数据
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<IEnumerable<BookAndBookTagRelationship>> GetByBookTagIdAsync(long bookTagId);

        /// <summary>
        /// 创建书籍与标签的关联
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="bookTagId"></param>
        /// <returns></returns>
        Task CreateRelationshipAsync(long bookId, IEnumerable<long> bookTagId);

        /// <summary>
        /// 根据Book.Id删除关联
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task DeleteByBookIdAsync(long bookId);

        /// <summary>
        /// 根据Book.Id删除关联
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task DeleteByBookIdAsync(IEnumerable<long> bookIds);


        /// <summary>
        /// 根据BookTag.Id删除关联
        /// </summary>
        /// <param name="bookTagId"></param>
        /// <returns></returns>
        Task DeleteByBookTagIdAsync(long bookTagId);

        /// <summary>
        /// 根据BookTag.Id删除关联
        /// </summary>
        /// <param name="bookTagIds"></param>
        /// <returns></returns>
        Task DeleteByBookTagIdAsync(IEnumerable<long> bookTagIds);
    }
}
