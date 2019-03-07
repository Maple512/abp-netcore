namespace AbpLearning.Application.CloudBookLists.Books
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Base;
    using Model;

    /// <summary>
    /// 书籍 应用服务 接口
    /// </summary>
    public interface IBookAppService : IAsyncAppService<long, BookUpdateOutput, BookPagedOutput, EntityDto<long>, EntityDto<long>, BookPagedInput, BookCreateInput, EntityDto<long>, BookUpdateInput, EntityDto<long>>
    {
        /// <summary>
        /// 检查书名
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        bool CheckBookName(string bookName);

        /// <summary>
        /// 获取书单下引用的所有书籍
        /// </summary>
        /// <param name="bookList">bookList</param>
        /// <returns></returns>
        Task<List<BookViewOutput>> GetBooksAsync(EntityDto<long> bookList);

        /// <summary>
        /// 批量删除
        /// 
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task BatchDeleteAsync(List<long> bookIds);
    }
}
