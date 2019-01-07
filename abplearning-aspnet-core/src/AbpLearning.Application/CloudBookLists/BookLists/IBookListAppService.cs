namespace AbpLearning.Application.CloudBookLists.BookLists
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Model;

    public interface IBookListAppService : IApplicationService
    {
        /// <summary>
        /// 书单 分页
        /// </summary>
        /// <param name="filter">书单分页</param>
        /// <returns></returns>
        Task<PagedResultDto<BookListPagedModel>> GetPagedAsync(BookListPagedFilterAndSortedModel filter);

        /// <summary>
        /// 书单 更新模型
        /// </summary>
        /// <param name="model">书单</param>
        /// <returns></returns>
        Task<BookListEditModel> GetEditAsync(EntityDto<long> model);

        /// <summary>
        /// 书单 获取书籍引用的所有书单
        /// </summary>
        /// <param name="model">书籍</param>
        /// <returns></returns>
        Task<List<BookListEditModel>> GetListEditAsync(EntityDto<long> model);

        /// <summary>
        /// 书单 创建/更新
        /// </summary>
        /// <param name="model">书单</param>
        /// <returns></returns>
        Task<long> CreateOrUpdateAsync(BookListEditModel model);

        /// <summary>
        /// 书单 删除
        /// </summary>
        /// <param name="model">书单</param>
        /// <returns></returns>
        Task DeleteAsync(EntityDto<long> model);

        /// <summary>
        /// 书单 批量删除
        /// </summary>
        /// <param name="bookListIds">书单</param>
        /// <returns></returns>
        Task BatchDeleteAsync(List<long> bookListIds);
    }
}
