namespace AbpLearning.Application.CloudBookList.Book
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using Abp.UI;
    using AbpLearning.Core.CloudBookList.BookLiseCells.DomainService;
    using AbpLearning.Core.CloudBookList.BookLists.DomainService;
    using AbpLearning.Core.CloudBookList.Books.DomainService;
    using AbpLearning.Core.CloudBookList.BookTags.DomainService;
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Model;

    /// <summary>
    /// 书籍 应用服务
    /// </summary>
    [AbpAuthorize(AbpLearningPermissions.BookNode)]
    public class BookAppService : AbpLearningAppServiceBase, IBookAppService
    {
        private readonly IBookDomainService _book;

        private readonly IBookListCellDomainService _bookListCell;

        private readonly IBookListDomainService _bookList;

        private readonly IBookTagDomainService _bookTag;

        public BookAppService(
            IBookDomainService book,
            IBookListCellDomainService bookListCell,
            IBookListDomainService bookList,
            IBookTagDomainService bookTag)
        {
            _book = book;
            _bookListCell = bookListCell;
            _bookList = bookList;
            _bookTag = bookTag;
        }

        /// <summary>
        /// 批量删除
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
        /// 创建、更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateAsync(BookEditModel model)
        {
            CreateOrUpdateCheck(model);

            var entity = model.MapTo<Core.CloudBookList.Books.Book>();

            await _book.CreateOrUpdateAsync(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteAsync(EntityDto<long> model)
        {
            // TODO:检查BookListCell/BookTag在Book删除之后，是否会自动删除（IsDeleted=true）
            if (_book.GetAll().Any(m => m.Id == model.Id))
            {
                // BookTag
                // await _bookTag.DeleteTagForBookIdAsync(model.Id);

                // Book
                await _book.DeleteAsync(model.Id);

                // BookListCell 
                // await _bookListCell.DeleteForBookAsync(model.Id);
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

            return entity.MapTo<BookEditModel>();
        }

        /// <summary>
        /// 分页
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
            var query = _book.GetAll();

            // 存在性校验
            if (model.Id.HasValue)
            {
                if (query.Any(m => m.Id != model.Id))
                {
                    throw new UserFriendlyException(L("DataIsNotExistedByEditFailed"));
                }
            }

            // 书名重复校验
            if (query.WhereIf(model.Id.HasValue, m => m.Id != model.Id).Any(m => m.Name == model.Name))
            {
                throw new UserFriendlyException(L("BookNameIsAlreadyExists"));
            }

            // 书签数量校验
            if (model.Tags.Count > Core.CloudBookList.Books.Book.TagsMaxLength)
            {
                throw new UserFriendlyException(L("BookHasUpBookTags", Core.CloudBookList.Books.Book.TagsMaxLength));
            }
        }
    }
}
