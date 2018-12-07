namespace AbpLearning.Application.CloudBookList.BookTag
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Book.Model;
    using Model;

    /// <summary>
    /// 书签 应用服务 接口
    /// </summary>
    public interface IBookTagAppService : IApplicationService
    {
        Task<PagedResultDto<BookTagPagedModel>> GetPagedAsync(BookTagPagedFilterAndSortedModel model);

        Task<BookViewModel> GetAsync(EntityDto<long> model);

        Task CreateAsync(BookTagEditModel model);

        Task UpdateAsync(BookTagEditModel model);

        Task DeleteAsync(EntityDto<long> model);

        Task BatchDeleteAsync(IEnumerable<long> bookTagIds);
    }
}
