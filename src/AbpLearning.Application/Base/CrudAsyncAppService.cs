namespace AbpLearning.Application.Base
{
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Entities;
    using Abp.Domain.Repositories;
    using Abp.Linq;
    using Abp.UI;

    /// <summary>
    /// 应用程序服务基类（基本方法：GetViewOutput,GetPaged,GetUpdateOutput,CreateInput,UpdateInput)
    /// </summary>
    public abstract class CrudAsyncAppService<TEntity, TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, TGetPagedInput, TGetUpdateOutput, TCreateInput, TUpdateInput>
        : CrudAsyncAppService<TEntity, TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, TGetPagedInput, TGetUpdateOutput, TCreateInput, TUpdateInput,
         EntityDto<TPrimaryKey>, NullableIdDto<TPrimaryKey>>
         where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : struct
        where TGetViewOutput : INullIdEntityDto
        where TGetPagedInput : IPagedResultRequest
        where TGetPagedOutput : IEntityDto<TPrimaryKey>
        where TGetUpdateOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : INullIdEntityDto
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        protected CrudAsyncAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
    }

    /// <summary>
    /// 应用程序服务基类（基本方法：GetViewOutput,GetPaged,GetUpdateOutput,CreateInput,UpdateInput,GetUpdateInput,GetViewInput)
    /// </summary>
    public abstract class CrudAsyncAppService<TEntity, TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, TGetPagedInput, TGetUpdateOutput, TCreateInput, TUpdateInput,
         TGetUpdateInput, TGetViewInput>
        : CrudAsyncAppService<TEntity, TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, TGetPagedInput, TGetUpdateOutput, TCreateInput, TUpdateInput,
         TGetUpdateInput, TGetViewInput, NullableIdDto<TPrimaryKey>, NullableIdDto<TPrimaryKey>, NullableIdDto<TPrimaryKey>>
         where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : struct
        where TGetViewOutput : INullIdEntityDto
        where TGetPagedInput : IPagedResultRequest
        where TGetPagedOutput : IEntityDto<TPrimaryKey>
        where TGetUpdateOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : INullIdEntityDto
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetUpdateInput : IEntityDto<TPrimaryKey>
        where TGetViewInput : NullableIdDto<TPrimaryKey>
    {
        protected CrudAsyncAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
    }

    /// <summary>
    /// 应用程序服务基类（基本方法：GetViewOutput,GetPaged,GetUpdateOutput,CreateInput,UpdateInput,GetUpdateInput,GetViewInput,UpdateOutput,CreateOutput,DeleteInput)
    /// </summary>
    public abstract class CrudAsyncAppService<TEntity, TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, TGetPagedInput, TGetUpdateOutput, TCreateInput, TUpdateInput,
         TGetUpdateInput, TGetViewInput, TUpdateOutput, TCreateOutput, TDeleteInput>
        : CrudAsyncAppServiceBase<TEntity, TPrimaryKey, TGetPagedInput>
        , ICrudAsyncAppService<TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, TGetPagedInput, TGetUpdateOutput, TCreateInput, TUpdateInput,
         TGetUpdateInput, TGetViewInput, TUpdateOutput, TCreateOutput, TDeleteInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : struct
        where TGetViewOutput : INullIdEntityDto
        where TGetPagedInput : IPagedResultRequest
        where TGetPagedOutput : IEntityDto<TPrimaryKey>
        where TGetUpdateOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : INullIdEntityDto
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetUpdateInput : IEntityDto<TPrimaryKey>
        where TGetViewInput : NullableIdDto<TPrimaryKey>
        where TUpdateOutput : NullableIdDto<TPrimaryKey>
        where TCreateOutput : NullableIdDto<TPrimaryKey>
        where TDeleteInput : NullableIdDto<TPrimaryKey>
    {
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        protected CrudAsyncAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
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

            var entity = ObjectMapper.Map<TEntity>(input);

            await Repository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<TCreateOutput>(entity);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <returns></returns>
        public virtual async Task DeleteAsync(TDeleteInput input)
        {
            CheckDeletePermission();

            await Repository.DeleteAsync(input.Id.GetValueOrDefault());
        }

        /// <summary>
        /// Get Paged
        /// </summary>
        /// <returns></returns>
        public virtual async Task<PagedResultDto<TGetPagedOutput>> GetPagedAsync(TGetPagedInput input)
        {
            CheckGetPagedPermission();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TGetPagedOutput>(
                totalCount,
                entities.Select(m => ObjectMapper.Map<TGetPagedOutput>(m)).ToList()
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

        /// <summary>
        /// Get Update
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<TGetUpdateOutput> GetUpdateAsync(TGetUpdateInput input)
        {
            CheckGetPermission();

            var entity = await Repository.GetAsync(input.Id);

            if (entity == null)
            {
                throw new UserFriendlyException(L("NotFoundData"));
            }

            return ObjectMapper.Map<TGetUpdateOutput>(entity);
        }

        /// <summary>
        /// Get View(by id to get view,need override)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<TGetViewOutput> GetViewAsync(TGetViewInput input)
        {
            CheckGetPermission();

            var entity = await Repository.GetAsync(input.Id.GetValueOrDefault());

            if (entity == null)
            {
                throw new UserFriendlyException(L("NotFoundData"));
            }

            return ObjectMapper.Map<TGetViewOutput>(entity);
        }
    }
}
