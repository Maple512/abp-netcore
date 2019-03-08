namespace AbpLearning.Application.CloudBookLists.BookLists
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Base;
    using Dto;

    public interface IBookListAppService : ICrudAsyncAppService<long, BookListGetViewOutput, BookListGetPagedOutput, BookListGetPagedInput, BookListGetUpdateOutput, BookListCreateInput, BookListUpdateInput>
    {
        /// <summary>
        /// 书单 获取书籍引用的所有书单
        /// </summary>
        /// <param name="model">书籍</param>
        /// <returns></returns>
        Task<List<BookListCreateInput>> GetListEditAsync(EntityDto<long> model);

        /// <summary>
        /// 书单 批量删除
        /// </summary>
        /// <param name="bookListIds">书单</param>
        /// <returns></returns>
        Task BatchDeleteAsync(List<long> bookListIds);
    }
}
