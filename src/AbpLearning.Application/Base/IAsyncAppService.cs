namespace AbpLearning.Application.Base
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 应用程序服务基接口（基本方法：Get)
    /// </summary>
    public interface IAsyncAppService<TPrimaryKey, TGetOutput, in TGetInput>
        : IApplicationService
        where TGetInput : IEntityDto<TPrimaryKey>
        where TGetOutput : IEntityDto<TPrimaryKey>
    {
        Task<TGetOutput> GetAsync(TGetInput input);
    }

    /// <summary>
    /// 应用程序服务基接口（基本方法：Get,GetPaged)
    /// </summary>
    public interface IAsyncAppService<TPrimaryKey, TGetOutput, TPagedOutput,
        in TGetPagedInput, in TGetInput>
        : IApplicationService
        where TGetInput : IEntityDto<TPrimaryKey>
        where TGetOutput : IEntityDto<TPrimaryKey>
        where TGetPagedInput : IPagedResultRequest
        where TPagedOutput : IEntityDto<TPrimaryKey>
    {
        Task<TGetOutput> GetAsync(TGetInput input);

        Task<PagedResultDto<TPagedOutput>> GetPagedAsync(TGetPagedInput input);
    }

    /// <summary>
    /// 应用程序服务基接口（基本方法：Get,GetPaged,Create)
    /// </summary>
    public interface IAsyncAppService<TPrimaryKey, TGetOutput, TPagedOutput, TCreateOutput,
        in TGetPagedInput, in TCreateInput, in TGetInput>
        : IApplicationService
        where TGetInput : IEntityDto<TPrimaryKey>
        where TGetOutput : IEntityDto<TPrimaryKey>
        where TGetPagedInput : IPagedResultRequest
        where TPagedOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
        where TCreateOutput : IEntityDto<TPrimaryKey>
    {
        Task<TGetOutput> GetAsync(TGetInput input);

        Task<PagedResultDto<TPagedOutput>> GetPagedAsync(TGetPagedInput input);

        Task<TCreateOutput> CreateAsync(TCreateInput input);
    }

    /// <summary>
    /// 应用程序服务基接口（基本方法：Get,GetPaged,Create,Update)
    /// </summary>
    public interface IAsyncAppService<TPrimaryKey, TGetOutput, TPagedOutput, TCreateOutput, TUpdateOutput,
        in TGetPagedInput, in TCreateInput, in TGetInput, in TUpdateInput>
        : IApplicationService
        where TGetInput : IEntityDto<TPrimaryKey>
        where TGetOutput : IEntityDto<TPrimaryKey>
        where TGetPagedInput : IPagedResultRequest
        where TPagedOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
        where TCreateOutput : IEntityDto<TPrimaryKey>
        where TUpdateOutput : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        Task<TGetOutput> GetAsync(TGetInput input);

        Task<PagedResultDto<TPagedOutput>> GetPagedAsync(TGetPagedInput input);

        Task<TCreateOutput> CreateAsync(TCreateInput input);

        Task<TUpdateOutput> UpdateAsync(TUpdateInput input);
    }

    /// <summary>
    /// 应用程序服务基接口（基本方法：Get,GetPaged,Create,Update,Delete)
    /// </summary>
    public interface IAsyncAppService<TPrimaryKey, TGetOutput, TPagedOutput, TCreateOutput, TUpdateOutput,
        in TGetPagedInput, in TCreateInput, in TGetInput, in TUpdateInput, in TDeleteInput>
        : IApplicationService
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

        Task<TGetOutput> GetAsync(TGetInput input);

        Task<PagedResultDto<TPagedOutput>> GetPagedAsync(TGetPagedInput input);

        Task<TCreateOutput> CreateAsync(TCreateInput input);

        Task<TUpdateOutput> UpdateAsync(TUpdateInput input);

        Task DeleteAsync(TDeleteInput input);
    }
}
