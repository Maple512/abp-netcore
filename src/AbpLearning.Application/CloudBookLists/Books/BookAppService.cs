﻿namespace AbpLearning.Application.CloudBookLists.Books
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
    using AbpLearning.Core.CloudBookLists.Books.DomainService;
    using Core;
    using Core.CloudBookLists;
    using Core.CloudBookLists.Books;
    using Microsoft.EntityFrameworkCore;
    using Model;

    /// <summary>
    /// 书籍 应用服务
    /// </summary>
    [AbpAuthorize(AbpLearningPermissions.Book)]
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

        /// <summary>
        /// 创建、更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<long> CreateOrUpdateAsync(BookEditModel model)
        {
            CreateOrUpdateCheck(model);

            var entity = model.MapTo<Book>();

            return await _book.CreateOrUpdateGetIdAsync(entity);
        }

        /// <summary>
        /// 获取修改模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BookEditModel> GetEditAsync(EntityDto<long> model)
        {
            var entity = await _book.GetAsync(model.Id);

            if (entity == null)
            {
                throw new UserFriendlyException(L("NotFoundData"));
            }

            var editModel = entity?.MapTo<BookEditModel>();

            return editModel;
        }

        /// <summary>
        /// 获取书单下引用的所有书籍
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<List<BookEditModel>> GetListEditAsync(EntityDto<long> model)
        {
            var entities = await _manager.GetBookForBookListAsync(model.Id);

            return entities?.MapTo<List<BookEditModel>>();
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
                await _manager.DeleteForBookAsync(model.Id);
            }
            else
            {
                throw new UserFriendlyException(L("DeleteFailedBasedOnId"));
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.Book + AbpLearningPermissions.Action.BatchdDelete)]
        public async Task BatchDeleteAsync(List<long> bookIds)
        {
            await _manager.BatchDeleteForBookAsync(bookIds);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.Book + AbpLearningPermissions.Action.Query)]
        public async Task<PagedResultDto<BookPagedModel>> GetPagedAsync(BookPagedFilteringModel filter)
        {
            var queryBooks = Entities
                .WhereIf(!filter.Name.IsNullOrWhiteSpace(), m => m.Name.Contains(filter.Name) || m.Author.Contains(filter.Name));

            var count = await queryBooks.CountAsync();

            var entityList = queryBooks.OrderBy(filter.Sorting).PageBy(filter).Include(m => m.Tags);

            var pagedModels = entityList.MapTo<List<BookPagedModel>>();

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
            if (model.Id.HasValue & model.Id != default(long?))
            {
                if (Entities.Any(m => m.Id != model.Id))
                {
                    throw new UserFriendlyException(L("NotFoundData"));
                }
            }

            // 书名重复校验
            if (Entities.WhereIf(model.Id.HasValue & model.Id != default(long?), m => m.Id != model.Id).Any(m => m.Name == model.Name))
            {
                throw new UserFriendlyException(L("BookNameIsAlreadyExists"));
            }
        }
    }
}