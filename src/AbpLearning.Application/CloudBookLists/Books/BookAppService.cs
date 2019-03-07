namespace AbpLearning.Application.CloudBookLists.Books
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using Abp.UI;
    using AbpLearning.Core.CloudBookLists.Books.DomainService;
    using Base;
    using Core;
    using Core.CloudBookLists;
    using Core.CloudBookLists.Books;
    using Model;

    /// <summary>
    /// 书籍 应用服务
    /// </summary>
    [AbpAuthorize(AbpLearningPermissions.Book)]
    public class BookAppService :
        AsyncAppService<Book, long, BookUpdateOutput, BookPagedOutput, EntityDto<long>, EntityDto<long>,
            BookPagedInput, BookCreateInput, EntityDto<long>, BookUpdateInput, EntityDto<long>>
        , IBookAppService
    {
        private readonly IBookDomainService _book;

        private readonly ICloudBookListManager _manager;

        public BookAppService(IBookDomainService book, ICloudBookListManager manager, IRepository<Book, long> repository) : base(repository)
        {
            _book = book;
            _manager = manager;
        }

        #region PermissionName

        protected override string GetPermissionName => AbpLearningPermissions.Book + AbpLearningPermissions.Action.Query;

        protected override string CreatePermissionName => AbpLearningPermissions.Book + AbpLearningPermissions.Action.Create;

        protected override string GetPagedPermissionName => AbpLearningPermissions.Book + AbpLearningPermissions.Action.Query;

        protected override string DeletePermissionName => AbpLearningPermissions.Book + AbpLearningPermissions.Action.Delete;

        protected override string UpdatePermissionName => AbpLearningPermissions.Book + AbpLearningPermissions.Action.Update;

        #endregion

        private IQueryable<Book> Entities => _book.GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<EntityDto<long>> CreateAsync(BookCreateInput input)
        {
            CheckCreatePermission();

            if (CheckBookName(input.Name))
            {
                throw new UserFriendlyException(L("BookNameIsAlreadyExists"));
            }

            var entity = ObjectMapper.Map<Book>(input);

            await Repository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<EntityDto<long>>(entity);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<EntityDto<long>> UpdateAsync(BookUpdateInput input)
        {
            CheckUpdatePermission();

            if (CheckBookName(input.Name))
            {
                throw new UserFriendlyException(L("BookNameIsAlreadyExists"));
            }

            var entity = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, entity);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<EntityDto<long>>(entity);
        }

        /// <summary>
        /// 获取书单下引用的所有书籍
        /// </summary>
        /// <param name="bookList"></param>
        /// <returns></returns>
        public async Task<List<BookViewOutput>> GetBooksAsync(EntityDto<long> bookList)
        {
            var entities = await _manager.GetBookForBookListAsync(bookList.Id);

            return ObjectMapper.Map<List<BookViewOutput>>(entities);
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
        /// 创建过滤查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected override IQueryable<Book> CreateFilteredQuery(BookPagedInput input)
        {
            return Entities.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), m => m.Name.Contains(input.FilterText) || m.Author.Contains(input.FilterText));
        }

        /// <summary>
        /// 书名重复性校验
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public bool CheckBookName(string bookName)
        {
            // 书名重复校验
            return Entities.Any(m => m.Name == bookName);
        }
    }
}
