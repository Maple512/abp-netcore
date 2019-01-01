namespace AbpLearning.Application.CloudBookList.BookTag
{
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using Abp.UI;
    using AbpLearning.Core.CloudBookList.BookTags.DomainService;
    using Core;
    using Model;

    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize(AbpLearningPermissions.BookNode)]
    public class BookTagAppService : AbpLearningAppServiceBase, IBookTagAppService
    {
        private readonly IBookTagDomainService _bookTag;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookTagDomainService"></param>
        public BookTagAppService(IBookTagDomainService bookTagDomainService)
        {
            _bookTag = bookTagDomainService;
        }

        /// <summary>
        /// 编辑模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BookTagEditModel> GetEditAsync(EntityDto<long> model)
        {
            var entity = await _bookTag.GetAsync(model.Id);

            return entity.MapTo<BookTagEditModel>();
        }

        /// <summary>
        /// 视图模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BookTagViewModel> GetViewAsync(EntityDto<long> model)
        {
            var entity = await _bookTag.GetAsync(model.Id);

            return entity.MapTo<BookTagViewModel>();
        }

        /// <summary>
        /// 创建/更新
        /// </summary>
        /// <param name="model">更新模型</param>
        /// <returns></returns>
        public async Task CreateOrUpdateAsync(BookTagEditModel model)
        {
            CraetOrUpdateCheck(model);

            var entity = model.MapTo<Core.CloudBookList.BookTags.BookTag>();

            await _bookTag.CreateOrUpdateAsync(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteAsync(EntityDto<long> model)
        {
            await _bookTag.DeleteAsync(model.Id);
        }

        /// <summary>
        /// 创建/更新 校验
        /// </summary>
        /// <param name="model"></param>
        private void CraetOrUpdateCheck(BookTagEditModel model)
        {
            var query = _bookTag.GetAll();

            // 更新时，校验是否存在
            if (model.Id.HasValue)
            {
                if (query.Any(m => m.Id != model.Id))
                {
                    throw new UserFriendlyException(L("DataIsNotExistedByEditFailed"));
                }
            }
            else
            {
                // 是否达到最大书签数
                if (query.Count(m => m.BookId == model.BookId) >= Core.CloudBookList.Books.Book.TagsMaxLength)
                {
                    throw new UserFriendlyException(L("BookHasUpBookTags", Core.CloudBookList.Books.Book.TagsMaxLength));
                }
            }

            // 重复性校验
            if (query.WhereIf(model.Id.HasValue, m => m.Id != model.Id.Value).Any(m => m.Name != model.Name))
            {
                throw new UserFriendlyException(L("BookTagNameIsRepeat"));
            }
        }
    }
}
