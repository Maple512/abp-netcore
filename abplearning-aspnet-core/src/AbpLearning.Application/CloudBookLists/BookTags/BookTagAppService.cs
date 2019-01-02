namespace AbpLearning.Application.CloudBookLists.BookTags
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Domain.Uow;
    using Abp.UI;
    using AbpLearning.Core.CloudBookLists.BookTags.DomainService;
    using Core;
    using Core.CloudBookLists.BookTags;
    using Microsoft.EntityFrameworkCore;
    using Model;

    [AbpAuthorize(AbpLearningPermissions.BookNode)]
    public class BookTagAppService : AbpLearningAppServiceBase, IBookTagAppService
    {
        private readonly IBookTagDomainService _bookTag;

        private IQueryable<BookTag> BookTags => _bookTag.GetAll();

        public BookTagAppService(IBookTagDomainService bookTagDomainService)
        {
            _bookTag = bookTagDomainService;
        }

        /// <summary>
        /// 获取Book中的所有tag
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        public async Task<List<BookTagEditModel>> GetEditForBookAsync(EntityDto<long> bookModel)
        {
            var entity = await BookTags.Where(m => m.BookId == bookModel.Id).ToListAsync();

            return entity.MapTo<List<BookTagEditModel>>();
        }

        /// <summary>
        /// 获取Book中的所有tag
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        public async Task<List<BookTagViewModel>> GetViewForBookAsync(EntityDto<long> bookModel)
        {
            var entity = await BookTags.Where(m => m.BookId == bookModel.Id).ToListAsync();

            return entity.MapTo<List<BookTagViewModel>>();
        }

        /// <summary>
        /// 创建Book的tag
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        [UnitOfWork]
        public async Task CreateForBookAsync(List<BookTagEditModel> bookModel)
        {
            foreach (var model in bookModel)
            {
                CraetCheck(model);

                var entity = model.MapTo<BookTag>();

                await _bookTag.InsertAsync(entity);
            }
        }

        /// <summary>
        /// 删除Book的tag
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        public async Task DeleteForBookAsync(EntityDto<long> bookModel)
        {
            await _bookTag.DeleteAsync(bookModel.Id);
        }

        /// <summary>
        /// 创建 校验
        /// </summary>
        /// <param name="model"></param>
        private void CraetCheck(BookTagEditModel model)
        {
            // 是否达到最大书签数
            if (BookTags.Count(m => m.BookId == model.BookId) >= Core.CloudBookLists.Books.Book.TagsMaxLength)
            {
                throw new UserFriendlyException(L("BookHasUpBookTags", Core.CloudBookLists.Books.Book.TagsMaxLength));
            }
        }
    }
}
