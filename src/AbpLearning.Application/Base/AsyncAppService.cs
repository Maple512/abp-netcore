namespace AbpLearning.Application.Base
{
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Entities;
    using Abp.Domain.Repositories;
    using Abp.Linq;

    /// <summary>
    /// 应用程序服务基类（基本方法：Get)
    /// </summary>
    public abstract class AsyncAppService<TEntity, TPrimaryKey, TGetOutput, TGetInput>
        : AppServiceBase<TEntity, TPrimaryKey>, IAsyncAppService<TPrimaryKey, TGetOutput, TGetInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TGetOutput : IEntityDto<TPrimaryKey>
    {
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        public AsyncAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TGetOutput> GetAsync(TGetInput input)
        {
            CheckGetPermission();

            var entity = await Repository.GetAsync(input.Id);

            return ObjectMapper.Map<TGetOutput>(entity);
        }
    }

    /// <summary>
    /// 应用程序服务基类（基本方法：Get,GetPaged)
    /// </summary>
    public abstract class AsyncAppService<TEntity, TPrimaryKey, TGetOutput, TPagedOutput,
         TGetPagedInput, TGetInput>
        : AppServiceBase<TEntity, TPrimaryKey, TGetPagedInput>
        , IAsyncAppService<TPrimaryKey, TGetOutput, TPagedOutput,
         TGetPagedInput, TGetInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TGetOutput : IEntityDto<TPrimaryKey>
        where TGetPagedInput : IPagedResultRequest
        where TPagedOutput : IEntityDto<TPrimaryKey>
    {
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        public AsyncAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TGetOutput> GetAsync(TGetInput input)
        {
            CheckGetPermission();

            var entity = await Repository.GetAsync(input.Id);

            return ObjectMapper.Map<TGetOutput>(entity);
        }

        /// <summary>
        /// Get Paged
        /// </summary>
        /// <returns></returns>
        public virtual async Task<PagedResultDto<TPagedOutput>> GetPagedAsync(TGetPagedInput input)
        {
            CheckGetPagedPermission();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TPagedOutput>(
                totalCount,
                entities.Select(m => ObjectMapper.Map<TPagedOutput>(m)).ToList()
            );
        }
    }

    /// <summary>
    /// 应用程序服务基类（基本方法：Get,GetPaged,Create)
    /// </summary>
    public abstract class AsyncAppService<TEntity, TPrimaryKey, TGetOutput, TPagedOutput, TCreateOutput,
         TGetPagedInput, TCreateInput, TGetInput>
        : AppServiceBase<TEntity, TPrimaryKey, TGetPagedInput>
        , IAsyncAppService<TPrimaryKey, TGetOutput, TPagedOutput, TCreateOutput,
         TGetPagedInput, TCreateInput, TGetInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TGetOutput : IEntityDto<TPrimaryKey>
        where TGetPagedInput : IPagedResultRequest
        where TPagedOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
        where TCreateOutput : IEntityDto<TPrimaryKey>
    {
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        public AsyncAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TCreateOutput> CreateAsync(TCreateInput input)
        {
            CheckCreatePermission();

            var entity = await Repository.GetAsync(input.Id);
            return ObjectMapper.Map<TCreateOutput>(entity);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TGetOutput> GetAsync(TGetInput input)
        {
            CheckGetPermission();

            var entity = await Repository.GetAsync(input.Id);

            return ObjectMapper.Map<TGetOutput>(entity);
        }

        /// <summary>
        /// Get Paged
        /// </summary>
        /// <returns></returns>
        public virtual async Task<PagedResultDto<TPagedOutput>> GetPagedAsync(TGetPagedInput input)
        {
            CheckGetPagedPermission();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TPagedOutput>(
                totalCount,
                entities.Select(m => ObjectMapper.Map<TPagedOutput>(m)).ToList()
            );
        }
    }

    /// <summary>
    /// 应用程序服务基类（基本方法：Get,GetPaged,Create,Update)
    /// </summary>
    public abstract class AsyncAppService<TEntity, TPrimaryKey, TGetOutput, TPagedOutput, TCreateOutput, TUpdateOutput,
         TGetPagedInput, TCreateInput, TGetInput, TUpdateInput>
        : AppServiceBase<TEntity, TPrimaryKey, TGetPagedInput>
        , IAsyncAppService<TPrimaryKey, TGetOutput, TPagedOutput, TCreateOutput, TUpdateOutput,
         TGetPagedInput, TCreateInput, TGetInput, TUpdateInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TGetOutput : IEntityDto<TPrimaryKey>
        where TGetPagedInput : IPagedResultRequest
        where TPagedOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
        where TCreateOutput : IEntityDto<TPrimaryKey>
        where TUpdateOutput : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        public AsyncAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TCreateOutput> CreateAsync(TCreateInput input)
        {
            CheckCreatePermission();

            var entity = await Repository.GetAsync(input.Id);
            return ObjectMapper.Map<TCreateOutput>(entity);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TGetOutput> GetAsync(TGetInput input)
        {
            CheckGetPermission();

            var entity = await Repository.GetAsync(input.Id);

            return ObjectMapper.Map<TGetOutput>(entity);
        }

        /// <summary>
        /// Get Paged
        /// </summary>
        /// <returns></returns>
        public virtual async Task<PagedResultDto<TPagedOutput>> GetPagedAsync(TGetPagedInput input)
        {
            CheckGetPagedPermission();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TPagedOutput>(
                totalCount,
                entities.Select(m => ObjectMapper.Map<TPagedOutput>(m)).ToList()
            );
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TUpdateOutput> UpdateAsync(TUpdateInput input)
        {
            CheckUpdatePermission();

            var entity = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, entity);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<TUpdateOutput>(entity);
        }
    }

    /// <summary>
    /// 应用程序服务基类（基本方法：Get,GetPaged,Create,Update,Delete)
    /// </summary>
    public abstract class AsyncAppService<TEntity, TPrimaryKey, TGetOutput, TPagedOutput, TCreateOutput, TUpdateOutput,
         TGetPagedInput, TCreateInput, TGetInput, TUpdateInput, TDeleteInput>
        : AppServiceBase<TEntity, TPrimaryKey, TGetPagedInput>
        , IAsyncAppService<TPrimaryKey, TGetOutput, TPagedOutput, TCreateOutput, TUpdateOutput,
         TGetPagedInput, TCreateInput, TGetInput, TUpdateInput, TDeleteInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TGetOutput : IEntityDto<TPrimaryKey>
        where TGetPagedInput : IPagedResultRequest
        where TPagedOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
        where TCreateOutput : IEntityDto<TPrimaryKey>
        where TUpdateOutput : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        public AsyncAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TCreateOutput> CreateAsync(TCreateInput input)
        {
            CheckCreatePermission();

            var entity = await Repository.GetAsync(input.Id);
            return ObjectMapper.Map<TCreateOutput>(entity);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <returns></returns>
        public virtual Task DeleteAsync(TDeleteInput input)
        {
            CheckDeletePermission();

            return Repository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TGetOutput> GetAsync(TGetInput input)
        {
            CheckGetPermission();

            var entity = await Repository.GetAsync(input.Id);

            return ObjectMapper.Map<TGetOutput>(entity);
        }

        /// <summary>
        /// Get Paged
        /// </summary>
        /// <returns></returns>
        public virtual async Task<PagedResultDto<TPagedOutput>> GetPagedAsync(TGetPagedInput input)
        {
            CheckGetPagedPermission();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TPagedOutput>(
                totalCount,
                entities.Select(m => ObjectMapper.Map<TPagedOutput>(m)).ToList()
            );
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TUpdateOutput> UpdateAsync(TUpdateInput input)
        {
            CheckUpdatePermission();

            var entity = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, entity);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<TUpdateOutput>(entity);
        }
    }
}
