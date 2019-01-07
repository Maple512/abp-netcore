namespace AbpLearning.Application.CloudBookLists.BookLists
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
    using AbpLearning.Core.CloudBookLists.BookLists;
    using AbpLearning.Core.CloudBookLists.BookLists.DomainService;
    using Core;
    using Core.CloudBookLists;
    using Microsoft.EntityFrameworkCore;
    using Model;

    /// <summary>
    /// <see cref="BookList"/> 应用程序服务
    /// </summary>
    [AbpAuthorize(AbpLearningPermissions.BooklistNode)]
    public class BookListAppService : AbpLearningAppServiceBase, IBookListAppService
    {
        private readonly IBookListDomainService _bookList;

        private readonly ICloudBookListManager _manager;

        public BookListAppService(
            IBookListDomainService bookList,
            ICloudBookListManager manager)
        {
            _bookList = bookList;
            _manager = manager;
        }

        /// <summary>
        /// 书单 查询/更新
        /// </summary>
        /// <param name="model">书单</param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Create, AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Edit)]
        public async Task<long> CreateOrUpdateAsync(BookListEditModel model)
        {
            var entity = model.MapTo<BookList>();

            return await _bookList.CreateOrUpdateGetIdAsync(entity);
        }

        /// <summary>
        /// 书单 删除
        /// </summary>
        /// <param name="model">书单</param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Delete)]
        public async Task DeleteAsync(EntityDto<long> model)
        {
            await _manager.DeleteForBookListAsync(model.Id);
        }

        /// <summary>
        /// 书单 批量删除
        /// </summary>
        /// <param name="bookListIds">书单</param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.BatchdDelete)]
        public async Task BatchDeleteAsync(List<long> bookListIds)
        {
            await _manager.BatchDeleteForBookListAsync(bookListIds);
        }

        /// <summary>
        /// 书单 获取书单更新模型
        /// </summary>
        /// <param name="model">书单</param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Query)]
        public async Task<BookListEditModel> GetEditAsync(EntityDto<long> model)
        {
            var entity = await _bookList.GetAsync(model.Id);

            return entity.MapTo<BookListEditModel>();
        }

        /// <summary>
        /// 书单 获取书籍引用的所有书单
        /// </summary>
        /// <param name="model">书籍</param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Query)]
        public async Task<List<BookListEditModel>> GetListEditAsync(EntityDto<long> model)
        {
            var entities = await _manager.GetBookListForBookAsync(model.Id);

            return entities.MapTo<List<BookListEditModel>>();
        }

        /// <summary>
        /// 书单 分页
        /// </summary>
        /// <param name="filter">书单分页</param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.BooklistNode + AbpLearningPermissions.Query)]
        public async Task<PagedResultDto<BookListPagedModel>> GetPagedAsync(BookListPagedFilterAndSortedModel filter)
        {
            var query = _bookList.GetAll()
                .WhereIf(!filter.FilterText.IsNullOrWhiteSpace(),
                    m => m.Name.Contains(filter.FilterText));

            var count = await query.CountAsync();

            var entityList = await query.OrderBy(filter.Sorting)
                .PageBy(filter)
                .Include(m => m.Cells)
                .ToListAsync();

            var entityListDto = entityList.MapTo<List<BookListPagedModel>>();

            // TODO:等待优化
            if (!AbpSession.TenantId.HasValue)
            {

            }

            return new PagedResultDto<BookListPagedModel>(count, entityListDto);
        }
    }
}
