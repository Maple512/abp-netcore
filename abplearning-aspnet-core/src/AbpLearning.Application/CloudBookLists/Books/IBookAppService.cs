namespace AbpLearning.Application.CloudBookLists.Books
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Model;

    /// <summary>
    /// 书籍 应用服务 接口
    /// </summary>
    public interface IBookAppService : IApplicationService
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<PagedResultDto<BookPagedModel>> GetPagedAsync(BookPagedFilterAndSortedModel filter);

        /// <summary>
        /// 更新模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<BookEditModel> GetEditAsync(EntityDto<long> model);

        /// <summary>
        /// 创建/更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateOrUpdateAsync(BookEditModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task DeleteAsync(EntityDto<long> model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task BatchDeleteAsync(List<long> bookIds);
    }
}
