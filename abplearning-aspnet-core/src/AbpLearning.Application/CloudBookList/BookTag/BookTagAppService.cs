namespace AbpLearning.Application.CloudBookList.BookTag
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
    using AbpLearning.Application.CloudBookList.Book.Model;
    using AbpLearning.Core.CloudBookList.BookTags.DomainService;
    using AbpLearning.Core.CloudBookList.Relationships.DomainService;
    using Core;
    using Core.CloudBookList.BookTags;
    using Microsoft.EntityFrameworkCore;
    using Model;

    [AbpAuthorize(AbpLearningPermissions.BooktagNode)]
    public class BookTagAppService : AbpLearningAppServiceBase, IBookTagAppService
    {
        private readonly IBookTagDomainService _bookTag;

        private readonly IBookAndBookTagRelationshipDomainService _bookAndBookTag;

        public BookTagAppService(IBookTagDomainService bookTagDomainService, IBookAndBookTagRelationshipDomainService bookAndBookTag)
        {
            _bookTag = bookTagDomainService;
            _bookAndBookTag = bookAndBookTag;
        }

        /// <summary>
        /// Batch Delete
        /// </summary>
        /// <param name="bookTagIds"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooktagNode + AbpLearningPermissions.BatchdDelete)]
        public async Task BatchDeleteAsync(List<long> bookTagIds)
        {
            await _bookAndBookTag.BatchDeleteByBookTagIdAsync(bookTagIds);

            await _bookTag.BatchDeleteAsync(bookTagIds);
        }

        /// <summary>
        /// Create Or Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooktagNode + AbpLearningPermissions.Query, AbpLearningPermissions.BooktagNode + AbpLearningPermissions.Edit)]
        public async Task CreateOrUpdateAsync(BookTagEditModel model)
        {
            var entity = model.MapTo<BookTag>();

            await _bookTag.CreateOrUpdateAsync(entity);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooktagNode + AbpLearningPermissions.Delete)]
        public async Task DeleteAsync(EntityDto<long> model)
        {
            await _bookAndBookTag.DeleteByBookTagIdAsync(model.Id);

            await _bookTag.DeleteAsync(model.Id);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooktagNode + AbpLearningPermissions.Query)]
        public async Task<BookViewModel> GetAsync(EntityDto<long> model)
        {
            var entity = await _bookTag.GetAsync(model.Id);

            return entity.MapTo<BookViewModel>();
        }

        /// <summary>
        /// Paged
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooktagNode + AbpLearningPermissions.Query)]
        public async Task<PagedResultDto<BookTagPagedModel>> GetPagedAsync(BookTagPagedFilterAndSortedModel filter)
        {
            var query = _bookTag.GetAll()
                .WhereIf(!filter.Name.IsNullOrWhiteSpace(), m => m.Name.Contains(filter.Name));

            var count = await query.CountAsync();

            var entityList = await query.OrderBy(filter.Sorting).PageBy(filter).ToListAsync();

            var entityListDto = entityList.MapTo<List<BookTagPagedModel>>();

            foreach (var model in entityListDto)
            {
                var andBook = await _bookAndBookTag.GetByBookTagIdAsync(model.Id);

                model.ExistedBookCount = andBook.Select(m => m.BookId).Distinct().Count();
            }

            if (!AbpSession.TenantId.HasValue)
            {

            }

            return new PagedResultDto<BookTagPagedModel>(count, entityListDto);
        }
    }
}
