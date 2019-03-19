namespace AbpLearning.Application.CloudBookLists.BookLists
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using AbpLearning.Application.Base;
    using AbpLearning.Core.CloudBookLists.BookListCells.DomainService;
    using AbpLearning.Core.CloudBookLists.BookLists;
    using AbpLearning.Core.CloudBookLists.BookLists.DomainService;
    using Core;
    using Core.CloudBookLists;
    using Microsoft.EntityFrameworkCore;
    using Dto;

    /// <summary>
    /// <see cref="BookList"/> 应用程序服务
    /// </summary>
    public class BookListAppService : CrudAsyncAppService<BookList, long, BookListGetViewOutput, BookListGetPagedOutput, BookListGetPagedInput, BookListGetUpdateOutput, BookListCreateInput, BookListUpdateInput>
        , IBookListAppService
    {
        private readonly IBookListDomainService _bookList;

        private readonly IBookListCellDomainService _bookListCell;

        private readonly ICloudBookListManager _manager;

        public BookListAppService(
            IBookListDomainService bookList,
            IBookListCellDomainService bookListCell,
            ICloudBookListManager manager,
            IRepository<BookList, long> repository) : base(repository)
        {
            _bookList = bookList;
            _manager = manager;
            _bookListCell = bookListCell;
        }

        #region PermissionName

        protected override string NodePermissionName => AbpLearningPermissions.Booklist;

        #endregion 

        /// <summary>
        /// 删除书单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task DeleteAsync(NullableIdDto<long> input)
        {
            CheckDeletePermission();

            await _manager.DeleteForBookListAsync(input.Id.GetValueOrDefault());
        }

        /// <summary>
        /// 书单 批量删除
        /// </summary>
        /// <param name="bookListIds">书单</param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.BatchdDelete)]
        public async Task BatchDeleteAsync(List<long> bookListIds)
        {
            await _manager.BatchDeleteForBookListAsync(bookListIds);
        }

        /// <summary>
        /// 书单 获取书籍引用的所有书单
        /// </summary>
        /// <param name="model">书籍</param>
        /// <returns></returns>
        [AbpAuthorize(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Query)]
        public async Task<List<BookListCreateInput>> GetListEditAsync(EntityDto<long> model)
        {
            var entities = await _manager.GetBookListForBookAsync(model.Id);

            return ObjectMapper.Map<List<BookListCreateInput>>(entities);
        }

        protected override IQueryable<BookList> CreateFilteredQuery(BookListGetPagedInput input)
        {
            var query = _bookList.GetAll()
                .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), m => m.Name.Contains(input.FilterText))
                .Include(m => m.Cells);

            return query;
        }

        ///// <summary>
        ///// 书单 分页
        ///// </summary>
        ///// <param name="filter">书单分页</param>
        ///// <returns></returns>
        //[AbpAuthorize(AbpLearningPermissions.Booklist + AbpLearningPermissions.Action.Query)]
        //public async Task<PagedResultDto<BookListGetPagedOutput>> GetPagedAsync(BookListGetPagedInput filter)
        //{
        //    var query = _bookList.GetAll()
        //        .WhereIf(!filter.FilterText.IsNullOrWhiteSpace(),
        //            m => m.Name.Contains(filter.FilterText));

        //    var count = await query.CountAsync();

        //    var entityList = await query.OrderBy(filter.Sorting)
        //        .PageBy(filter)
        //        .Include(m => m.Cells)
        //        .ToListAsync();

        //    var entityListDto = ObjectMapper.Map<List<BookListGetPagedOutput>>(entityList);

        //    if (!AbpSession.TenantId.HasValue)
        //    {

        //    }

        //    return new PagedResultDto<BookListGetPagedOutput>(count, entityListDto);
        //}
    }
}
