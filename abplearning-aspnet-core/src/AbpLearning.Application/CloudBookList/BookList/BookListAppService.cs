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
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Model;

    [AbpAuthorize(AbpLearningPermissions.BooklistNode)]
    public class BookListAppService : AbpLearningAppServiceBase, IBookListAppService
    {
        private readonly IBookListDomainService _bookList;

        public BookListAppService(IBookListDomainService bookList)
        {
            _bookList = bookList;
        }

        /// <summary>
        /// Batch Delete
        /// </summary>
        /// <param name="bookListIds"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.BatchdDelete)]
        public async Task BatchDeleteAsync(List<long> bookListIds)
        {
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
            await _bookList.DeleteAsync(model.Id);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Query)]
        public async Task<BookListEditModel> GetEditAsync(EntityDto<long> model)
        {
            var entity = await _bookList.GetAsync(model.Id);

            return entity.MapTo<BookListEditModel>();
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
                .WhereIf(!filter.FilterText.IsNullOrWhiteSpace(),
                    m => m.Name.Contains(filter.FilterText));

            var count = await query.CountAsync();

            var entityList = await query.OrderBy(filter.Sorting).PageBy(filter).ToListAsync();

            var entityListDto = entityList.MapTo<List<BookListPagedModel>>();

            foreach (var model in entityListDto)
            {
                //var andBookRelationships = await _bookListAndBook.GetByBookListIdAsync(model.Id);

                //model.ExsitedBookCount = andBookRelationships.Select(m => m.BookId).Distinct().Count();
            }

            // TODO:等待优化
            if (!AbpSession.TenantId.HasValue)
            {

            }

            return new PagedResultDto<BookListPagedModel>(count, entityListDto);
        }
    }
}
