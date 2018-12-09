namespace AbpLearning.Core.CloudBookList.Relationships.DomainService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Domain.Services;

    public interface IBookListAndBookRelationshipDomainService : IDomainService
    {
        /// <summary>
        /// 根据BookList.Id获取与Book的所有关联
        /// </summary>
        /// <param name="bookListId"></param>
        /// <returns></returns>
        Task<IEnumerable<BookListAndBookRelationship>> GetByBookListIdAsync(long bookListId);


        /// <summary>
        /// 根据Book.Id获取所有关联
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<IEnumerable<BookListAndBookRelationship>> GetByBookIdAsync(long bookId);

        /// <summary>
        /// 增加关联
        /// </summary>
        /// <param name="bookListId"></param>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task AddRelationshipAsync(long bookListId, IEnumerable<long> bookIds);

        /// <summary>
        /// 删除关联
        /// </summary>
        /// <param name="bookListId"></param>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task DeleteRelationshipAsync(long bookListId, IEnumerable<long> bookIds);

        /// <summary>
        /// 根据Book.Id删除所有关联（在删除书籍时使用）
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task DeleteByBookIdAsync(long bookId);

        /// <summary>
        /// 根据Book.Id集合删除关联（批量删除书籍时使用）
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task BatchDeleteByBookIdAsync(IEnumerable<long> bookIds);

        /// <summary>
        /// 根据BookList.Id删除关联（在删除书单时使用）
        /// </summary>
        /// <param name="bookListId"></param>
        /// <returns></returns>
        Task DeleteByBookListIdAsync(long bookListId);

        /// <summary>
        /// 根据BookList.Id集合删除关联（批量删除书单时使用）
        /// </summary>
        /// <param name="bookListIds"></param>
        /// <returns></returns>
        Task BatchDeleteByBookListIdAsync(IEnumerable<long> bookListIds);
    }
}
