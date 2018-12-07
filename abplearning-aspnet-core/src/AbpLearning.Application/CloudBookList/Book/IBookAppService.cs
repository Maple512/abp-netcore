namespace AbpLearning.Application.CloudBookList.Book
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
        /// <param name="filterModel"></param>
        /// <returns></returns>
        Task<PagedResultDto<BookPagedModel>> GetPagedAsync(BookPagedFilterAndSortedModel filterModel);

        /// <summary>
        /// 视图模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<BookViewModel> GetAsync(EntityDto<long> model);

        Task CreateOrUpdateAsync(BookEditModel entity);

        Task DeleteAsync(EntityDto<long> model);

        Task BatchDeleteAsync(IEnumerable<long> bookIds);
    }
}
