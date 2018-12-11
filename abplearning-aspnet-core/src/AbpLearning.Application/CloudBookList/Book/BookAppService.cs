namespace AbpLearning.Application.CloudBookList.Book
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Abp;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using AbpLearning.Core.CloudBookList.Books.DomainService;
    using AbpLearning.Core.CloudBookList.Relationships.DomainService;
    using BookTag.Model;
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

        private readonly IBookAndBookTagRelationshipDomainService _bookAndBookTag;

        private readonly IBookListAndBookRelationshipDomainService _bookListAndBook;

        public BookAppService(
            IBookDomainService book,
            IBookAndBookTagRelationshipDomainService bookAndBookTag,
            IBookListAndBookRelationshipDomainService bookListAndBook)
        {
            _book = book;
            _bookAndBookTag = bookAndBookTag;
            _bookListAndBook = bookListAndBook;
        }

        [AbpAuthorize(AbpLearningPermissions.BookNode + AbpLearningPermissions.BatchdDelete)]
        public async Task BatchDeleteAsync(List<long> bookIds)
        {
            await _bookAndBookTag.BatchDeleteByBookIdAsync(bookIds);
            await _bookListAndBook.BatchDeleteByBookIdAsync(bookIds);
            await _book.BatchDeleteAsync(bookIds);
        }

        public async Task CreateOrUpdateAsync(BookEditModel model)
        {
            var entity = model.MapTo<Core.CloudBookList.Books.Book>();
            await _book.CreateOrUpdateAsync(entity);
        }

        public async Task DeleteAsync(EntityDto<long> model)
        {
            await _bookAndBookTag.DeleteByBookIdAsync(model.Id);
            await _bookListAndBook.DeleteByBookIdAsync(model.Id);
            await _book.DeleteAsync(model.Id);
        }

        public async Task<BookEditModel> GetForEditAsync(EntityDto<long> model)
        {
            var entity = await _book.GetAsync(model.Id);

            return entity.MapTo<BookEditModel>();
        }

        public async Task<BookViewModel> GetForViewAsync(EntityDto<long> model)
        {
            var entity = await _book.GetAsync(model.Id);

            return entity.MapTo<BookViewModel>();
        }

        [AbpAuthorize(AbpLearningPermissions.BookNode + AbpLearningPermissions.Query)]
        public async Task<PagedResultDto<BookPagedModel>> GetPagedAsync(BookPagedFilterAndSortedModel filter)
        {
            var queryBooks = _book.GetAll()
                .WhereIf(!filter.FilterText.IsNullOrWhiteSpace(), m => m.Name.Contains(filter.FilterText));

            var count = await queryBooks.CountAsync();

            var entityList = queryBooks.OrderBy(filter.Sorting).PageBy(filter);

            var pagedModels = entityList.MapTo<List<BookPagedModel>>();

            foreach (var model in pagedModels)
            {
                model.ExsitedBookListCount = _bookListAndBook.GetByBookIdAsync(model.Id).Result.Count();

                model.BookTags = _bookAndBookTag.GetByBookIdAsync(model.Id).Result
                    .Select(m => m.BookTag).OrderBy(m => m.Name).Take(5)
                    .MapTo<List<BookTagViewModel>>();
            }

            // TODO:等待
            if (!AbpSession.TenantId.HasValue)
            {

            }

            return new PagedResultDto<BookPagedModel>(count, pagedModels);
        }

        #region 与书签关联

        [AbpAuthorize(AbpLearningPermissions.BooktagNode)]
        public async Task AddBookTagRelationshipsAsync(BookAndBookTagEditModel bookAndBookTagEditModel)
        {
            var isExist = await _book.IsExistenceAsync(bookAndBookTagEditModel.BookId);
            if (isExist)
            {
                await _bookAndBookTag.AddRelationshipAsync(bookAndBookTagEditModel.BookId, bookAndBookTagEditModel.BookTagIds);
            }
            else
            {
                throw new AbpException("创建关联失败：该书籍不存在");
            }
        }

        [AbpAuthorize(AbpLearningPermissions.BooktagNode)]
        public async Task DeleteBookTagRelationshipsAsync(BookAndBookTagEditModel bookAndBookTagEditModel)
        {
            var isExist = await _book.IsExistenceAsync(bookAndBookTagEditModel.BookId);
            if (isExist)
            {
                await _bookAndBookTag.DeleteRelationshipAsync(bookAndBookTagEditModel.BookId, bookAndBookTagEditModel.BookTagIds);
            }
            else
            {
                throw new AbpException("创建关联失败：该书籍不存在");
            }
        }

        #endregion
    }
}
