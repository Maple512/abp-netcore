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
        /// 创建关联
        /// </summary>
        /// <param name="bookListId"></param>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task CreateRelationshipAsync(long bookListId, IEnumerable<long> bookIds);


        /// <summary>
        /// 根据Book.Id删除关联
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task DeleteByBookIdv(long bookId);


        /// <summary>
        /// 根据Book.Id集合删除关联
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task DeleteByBookIdAsync(IEnumerable<long> bookIds);


        /// <summary>
        /// 根据BookList.Id删除关联
        /// </summary>
        /// <param name="bookListId"></param>
        /// <returns></returns>
        Task DeleteByBookListIdAsync(long bookListId);


        /// <summary>
        /// 根据BookList.Id集合删除关联
        /// </summary>
        /// <param name="bookListIds"></param>
        /// <returns></returns>
        Task DeleteByBookListIdAsync(IEnumerable<long> bookListIds);
    }
}
