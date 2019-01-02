namespace AbpLearning.Application.CloudBookLists.Books
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Domain.Uow;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using Abp.UI;
    using AbpLearning.Core.CloudBookLists.BookLiseCells.DomainService;
    using AbpLearning.Core.CloudBookLists.BookLists.DomainService;
    using AbpLearning.Core.CloudBookLists.Books.DomainService;
    using AbpLearning.Core.CloudBookLists.BookTags.DomainService;
    using BookLists.Model;
    using BookTags.Model;
    using Core;
    using Core.CloudBookLists;
    using Core.CloudBookLists.Books;
    using Microsoft.EntityFrameworkCore;
    using Model;

    /// <summary>
    /// 书籍 应用服务
    /// </summary>
    [AbpAuthorize(AbpLearningPermissions.BookNode)]
    public class BookAppService : AbpLearningAppServiceBase, IBookAppService
    {
        private readonly IBookDomainService _book;

        private readonly ICloudBookListManager _manager;

        public BookAppService(
            IBookDomainService book,
            ICloudBookListManager manager)
        {
            _book = book;
            _manager = manager;
        }

        private IQueryable<Book> Entities => _book.GetAll();

        #region 已做

        /// <summary>
        /// 创建、更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateAsync(BookEditModel model)
        {
            CreateOrUpdateCheck(model);

            var entity = model.MapTo<Book>();

            if (model.Id.HasValue)
            {
                await _book.UpdateAsync(entity);
            }
            else
            {
                await _book.InsertAsync(entity);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteAsync(EntityDto<long> model)
        {
            if (Entities.Any(m => m.Id == model.Id))
            {
                await _manager.DeleteForBookAsync(bookId: model.Id);
            }
            else
            {
                throw new UserFriendlyException(L("DeleteFailedBasedOnId"));
            }
        }

        /// <summary>
        /// 获取修改模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BookEditModel> GetEditAsync(EntityDto<long> model)
        {
            var entity = await _book.GetAsync(model.Id);

            var editModel = entity.MapTo<BookEditModel>();

            editModel.Lists = (await _manager.GetBookListForBookAsync(model.Id))?.MapTo<List<BookListViewModel>>();

            return editModel;
        }

        #endregion

        /// <summary>
        /// 批量删除
        /// TODO:待做
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BookNode + AbpLearningPermissions.BatchdDelete)]
        public async Task BatchDeleteAsync(List<long> bookIds)
        {
            // BookTag
            // Book
            // BookListCell

            await _book.BatchDeleteAsync(bookIds);
        }

        /// <summary>
        /// 分页
        /// TODO:待做
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BookNode + AbpLearningPermissions.Query)]
        public async Task<PagedResultDto<BookPagedModel>> GetPagedAsync(BookPagedFilterAndSortedModel filter)
        {
            var queryBooks = _book.GetAll()
                .WhereIf(!filter.FilterText.IsNullOrWhiteSpace(), m => m.Name.Contains(filter.FilterText) || m.Author.Contains(filter.FilterText));

            var count = await queryBooks.CountAsync();

            var entityList = queryBooks.OrderBy(filter.Sorting).PageBy(filter);

            var pagedModels = entityList.MapTo<List<BookPagedModel>>();

            // TODO:待实现
            //foreach (var model in pagedModels)
            //{
            //    model.ExsitedBookListCount = _bookListAndBook.GetByBookIdAsync(model.Id).Result.Count();

            //    model.Tags = _bookAndBookTag.GetByBookIdAsync(model.Id).Result
            //        .Select(m => m.BookTag).OrderBy(m => m.Name).Take(5)
            //        .MapTo<List<BookTagViewModel>>();
            //}

            // TODO:待实现
            if (!AbpSession.TenantId.HasValue)
            {

            }

            return new PagedResultDto<BookPagedModel>(count, pagedModels);
        }

        /// <summary>
        /// 创建/更新 校验
        /// </summary>
        /// <param name="model"></param>
        private void CreateOrUpdateCheck(BookEditModel model)
        {
            // 存在性校验
            if (model.Id.HasValue)
            {
                if (Entities.Any(m => m.Id != model.Id))
                {
                    throw new UserFriendlyException(L("DataIsNotExistedByEditFailed"));
                }
            }

            // 书名重复校验
            if (Entities.WhereIf(model.Id.HasValue, m => m.Id != model.Id).Any(m => m.Name == model.Name))
            {
                throw new UserFriendlyException(L("BookNameIsAlreadyExists"));
            }

            // 书签数量校验
            if (model.Tags.Count > Book.TagsMaxLength)
            {
                throw new UserFriendlyException(L("BookHasUpBookTags", Book.TagsMaxLength));
            }
        }
    }
}
