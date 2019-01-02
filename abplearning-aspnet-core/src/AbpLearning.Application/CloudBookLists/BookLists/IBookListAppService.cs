namespace AbpLearning.Application.CloudBookLists.BookLists
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Model;

    public interface IBookListAppService : IApplicationService
    {
        Task<PagedResultDto<BookListPagedModel>> GetPagedAsync(BookListPagedFilterAndSortedModel filter);

        Task<BookListEditModel> GetEditAsync(EntityDto<long> model);

        Task CreateOrUpdateAsync(BookListEditModel model);

        Task DeleteAsync(EntityDto<long> model);

        Task BatchDeleteAsync(List<long> bookIds);
    }
}
