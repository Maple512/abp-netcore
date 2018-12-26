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
        Task<PagedResultDto<BookPagedModel>> GetPagedAsync(BookPagedFilterAndSortedModel filter);

        Task<BookEditModel> GetEditAsync(EntityDto<long> model);

        Task CreateOrUpdateAsync(BookEditModel model);

        Task DeleteAsync(EntityDto<long> model);

        Task BatchDeleteAsync(List<long> bookIds);

        #region 与书签关联

        /// <summary>
        /// 给书籍增加关联书签
        /// </summary>
        /// <param name="model"></param>
        /// <param name="bookTagIds"></param>
        /// <returns></returns>
        Task AddBookTagRelationshipsAsync(BookAndBookTagEditModel bookAndBookTagEditModel);

        /// <summary>
        /// 删除书籍的关联书签
        /// </summary>
        /// <param name="model"></param>
        /// <param name="bookTagIds"></param>
        /// <returns></returns>
        Task DeleteBookTagRelationshipsAsync(BookAndBookTagEditModel bookAndBookTagEditModel);

        #endregion

    }
}
