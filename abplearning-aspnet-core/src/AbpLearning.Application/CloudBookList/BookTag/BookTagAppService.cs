using System.ComponentModel;

namespace AbpLearning.Application.CloudBookList.BookTag
{
    using System.Collections.Generic;
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

    [AbpAuthorize(AbpLearningPermissions.BOOKTAG_NODE)]
    public class BookTagAppService : AbpLearningAppServiceBase, IBookTagAppService
    {
        private readonly IBookTagDomainService _bookTagDomainService;

        private readonly IBookAndBookTagRelationshipDomainService _bookAndBookTagRelationshipDomainService;

        public BookTagAppService(IBookTagDomainService bookTagDomainService, IBookAndBookTagRelationshipDomainService bookAndBookTagRelationshipDomainService)
        {
            _bookTagDomainService = bookTagDomainService;
            _bookAndBookTagRelationshipDomainService = bookAndBookTagRelationshipDomainService;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="bookTagIds">参数...</param>
        /// <remarks>备注...</remarks>
        /// <response code="200">Response 200 ...</response>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.BATCHD_DELETE)]
        public async Task BatchDeleteAsync(List<long> bookTagIds)
        {
            await _bookTagDomainService.BatchDeleteAsync(bookTagIds);
        }

        [AbpAuthorize(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.QUERY, AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.EDIT)]
        public async Task CreateOrUpdateAsync(BookTagEditModel model)
        {
            var entity = model.MapTo<BookTag>();
            await _bookTagDomainService.CreateOrUpdateAsync(entity);
        }

        [AbpAuthorize(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.DELETE)]
        public async Task DeleteAsync(EntityDto<long> model)
        {
            await _bookAndBookTagRelationshipDomainService.DeleteByBookTagIdAsync(model.Id);

            await _bookTagDomainService.DeleteAsync(model.Id);
        }

        [AbpAuthorize(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.QUERY)]
        public async Task<BookViewModel> GetAsync(EntityDto<long> model)
        {
            var entity = await _bookTagDomainService.GetAsync(model.Id);

            return entity.MapTo<BookViewModel>();
        }

        [AbpAuthorize(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.QUERY)]
        public async Task<PagedResultDto<BookTagPagedModel>> GetPagedAsync(BookTagPagedFilterAndSortedModel model)
        {
            var query = _bookTagDomainService.GetAll()
                .WhereIf(!model.Name.IsNullOrWhiteSpace(), m => m.Name.Contains(model.Name));

            var count = await query.CountAsync();

            var entityList = await query.OrderBy(model.Sorting).PageBy(model).ToListAsync();

            var entityListDto = entityList.MapTo<List<BookTagPagedModel>>();

            if (!AbpSession.TenantId.HasValue)
            {

            }

            return new PagedResultDto<BookTagPagedModel>(count, entityListDto);
        }
    }
}
