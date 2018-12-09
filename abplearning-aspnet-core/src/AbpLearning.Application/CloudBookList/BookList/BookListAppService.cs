namespace AbpLearning.Application.CloudBookList.BookList
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
    using AbpLearning.Core.CloudBookList.BookLists.DomainService;
    using AbpLearning.Core.CloudBookList.Relationships.DomainService;
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Model;

    [AbpAuthorize(AbpLearningPermissions.BooklistNode)]
    public class BookListAppService : AbpLearningAppServiceBase, IBookListAppService
    {
        private readonly IBookListDomainService _bookList;

        private readonly IBookListAndBookRelationshipDomainService _bookListAndBook;

        public BookListAppService(IBookListDomainService bookList, IBookListAndBookRelationshipDomainService bookListAndBook)
        {
            _bookList = bookList;
            _bookListAndBook = bookListAndBook;
        }

        /// <summary>
        /// Batch Delete
        /// </summary>
        /// <param name="bookListIds"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.BatchdDelete)]
        public async Task BatchDeleteAsync(List<long> bookListIds)
        {
            await _bookListAndBook.BatchDeleteByBookListIdAsync(bookListIds);

            await _bookList.BatchDeleteAsync(bookListIds);
        }

        /// <summary>
        /// Create Or Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Create, AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Edit)]
        public async Task CreateOrUpdateAsync(BookListEditModel model)
        {
            var entity = model.MapTo<Core.CloudBookList.BookLists.BookList>();

            await _bookList.CreateOrUpdateAsync(entity);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Delete)]
        public async Task DeleteAsync(EntityDto<long> model)
        {
            await _bookListAndBook.DeleteByBookListIdAsync(model.Id);

            await _bookList.DeleteAsync(model.Id);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Query)]
        public async Task<BookListViewModel> GetAsync(EntityDto<long> model)
        {
            var entity = await _bookList.GetAsync(model.Id);

            return entity.MapTo<BookListViewModel>();
        }

        /// <summary>
        /// Paged
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Query)]
        public async Task<PagedResultDto<BookListPagedModel>> GetPagedAsync(BookListPagedFilterAndSortedModel filter)
        {
            var query = _bookList.GetAll()
                .WhereIf(!filter.Name.IsNullOrWhiteSpace(),
                    m => m.Name.Contains(filter.Name))
                .WhereIf(!filter.Intro.IsNullOrWhiteSpace(),
                    m => m.Intro.Contains(filter.Intro));

            var count = await query.CountAsync();

            var entityList = await query.OrderBy(filter.Sorting).PageBy(filter).ToListAsync();

            var entityListDto = entityList.MapTo<List<BookListPagedModel>>();

            foreach (var model in entityListDto)
            {
                var andBookRelationships = await _bookListAndBook.GetByBookListIdAsync(model.Id);

                model.ExsitedBookCount = andBookRelationships.Select(m => m.BookId).Distinct().Count();
            }

            // TODO:等待
            if (!AbpSession.TenantId.HasValue)
            {

            }

            return new PagedResultDto<BookListPagedModel>(count, entityListDto);
        }

        #region 与书籍关联

        /// <summary>
        /// Add Book Relationships
        /// </summary>
        /// <param name="model"></param>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BookNode)]
        public async Task AddBookRelationshipsAsync(EntityDto<long> model, List<long> bookIds)
        {
            var isExist = await _bookList.IsExistenceAsync(model.Id);
            if (isExist)
            {
                await _bookListAndBook.AddRelationshipAsync(model.Id, bookIds);
            }
            else
            {
                throw new AbpException("创建关联失败：该书单不存在");
            }
        }

        /// <summary>
        /// Delete Book Relationships
        /// </summary>
        /// <param name="model"></param>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BookNode)]
        public async Task DeleteBookRelationshipsAsync(EntityDto<long> model, List<long> bookIds)
        {
            var isExist = await _bookList.IsExistenceAsync(model.Id);
            if (isExist)
            {
                await _bookListAndBook.DeleteRelationshipAsync(model.Id, bookIds);
            }
            else
            {
                throw new AbpException("删除关联失败：该书单不存在");
            }
        }

        #endregion
    }
}
