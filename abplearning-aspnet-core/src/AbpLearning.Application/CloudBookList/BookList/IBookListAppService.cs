namespace AbpLearning.Application.CloudBookList.BookList
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Model;

    public interface IBookListAppService : IApplicationService
    {
        Task<PagedResultDto<BookListPagedModel>> GetPagedAsync(BookListPagedFilterAndSortedModel filter);

        Task<BookListViewModel> GetAsync(EntityDto<long> model);

        Task CreateOrUpdateAsync(BookListEditModel model);

        Task DeleteAsync(EntityDto<long> model);

        Task BatchDeleteAsync(List<long> bookIds);

        #region 与书籍关联

        /// <summary>
        /// 增加关联
        /// </summary>
        /// <param name="model"></param>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task AddBookRelationshipsAsync(BookListAndBookEditModel bookListAndBookEditModel);

        /// <summary>
        /// 删除关联
        /// </summary>
        /// <param name="model"></param>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task DeleteBookRelationshipsAsync(BookListAndBookEditModel bookListAndBookEditModel);

        #endregion
    }
}
