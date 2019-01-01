namespace AbpLearning.Application.CloudBookList.BookTag
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Model;

    /// <summary>
    /// 书签 应用服务 接口
    /// </summary>
    public interface IBookTagAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<BookTagEditModel> GetEditAsync(EntityDto<long> model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<BookTagViewModel> GetViewAsync(EntityDto<long> model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateOrUpdateAsync(BookTagEditModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task DeleteAsync(EntityDto<long> model);
    }
}
