namespace AbpLearning.Application.CloudBookList.BookTag
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using AbpLearning.Application.CloudBookList.Book.Model;
    using AbpLearning.Application.CloudBookList.BookTag.Model;
    using AbpLearning.Core;
    using AbpLearning.Core.CloudBookList.BookTags.DomainService;
    using AbpLearning.Core.CloudBookList.Relationships.DomainService;
    using Core.CloudBookList.BookTags;
    using Microsoft.EntityFrameworkCore;

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

        [AbpAuthorize(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.BATCHD_DELETE)]
        public Task BatchDeleteAsync(IEnumerable<long> bookTagIds)
        {
            throw new NotImplementedException();
        }

        [AbpAuthorize(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.QUERY, AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.EDIT)]
        public async Task CreateOrUpdateAsync(BookTagEditModel model)
        {
            await _bookTagDomainService.CreateOrUpdateAsync(model.MapTo<BookTag>());

            //if (model.Id.HasValue)
            //{
            //    await UpdateAsync(model);
            //}
            //else
            //{
            //    await CreateAsync(model);
            //}
        }

        [AbpAuthorize(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.QUERY)]
        public Task CreateAsync(BookTagEditModel model)
        {
            throw new NotImplementedException();
        }

        [AbpAuthorize(AbpLearningPermissions.BOOKTAG_NODE + AbpLearningPermissions.EDIT)]
        public Task UpdateAsync(BookTagEditModel model)
        {
            throw new NotImplementedException();
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
