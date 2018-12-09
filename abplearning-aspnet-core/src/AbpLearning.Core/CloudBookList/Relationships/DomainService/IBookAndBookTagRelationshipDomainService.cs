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
        /// <param name="bookTagId"></param>
        /// <returns></returns>
        Task<IEnumerable<BookAndBookTagRelationship>> GetByBookTagIdAsync(long bookTagId);

        /// <summary>
        /// 增加书籍与书签的关联
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="bookTagIds"></param>
        /// <returns></returns>
        Task AddRelationshipAsync(long bookId, IEnumerable<long> bookTagIds);

        /// <summary>
        /// 删除关联
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="bookTagIds"></param>
        /// <returns></returns>
        Task DeleteRelationshipAsync(long bookId, IEnumerable<long> bookTagIds);

        /// <summary>
        /// 根据Book.Id删除关联（批量删除书籍时使用）
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task BatchDeleteByBookIdAsync(IEnumerable<long> bookIds);

        /// <summary>
        /// 根据Book.Id删除关联（在删除书籍时用）
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task DeleteByBookIdAsync(long bookId);

        /// <summary>
        /// 根据BookTag.Id删除关联（在删除书签时用）
        /// </summary>
        /// <param name="bookTagId"></param>
        /// <returns></returns>
        Task DeleteByBookTagIdAsync(long bookTagId);

        /// <summary>
        /// 根据BookTag.Id删除关联（批量删除书签时使用）
        /// </summary>
        /// <param name="bookTagIds"></param>
        /// <returns></returns>
        Task BatchDeleteByBookTagIdAsync(IEnumerable<long> bookTagIds);
    }
}
