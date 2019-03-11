namespace AbpLearning.Application.Base
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 应用程序服务基接口（基本方法：GetViewOutput,GetPaged,GetUpdateOutput,CreateInput,UpdateInput)
    /// </summary>
    public interface ICrudAsyncAppService<TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, in TGetPagedInput, TGetUpdateOutput, in TCreateInput, in TUpdateInput>
        : ICrudAsyncAppService<TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, TGetPagedInput, TGetUpdateOutput, TCreateInput, TUpdateInput,
         EntityDto<TPrimaryKey>, NullableIdDto<TPrimaryKey>, NullableIdDto<TPrimaryKey>, NullableIdDto<TPrimaryKey>, NullableIdDto<TPrimaryKey>>
       where TPrimaryKey : struct
        where TGetViewOutput : INullIdEntityDto
        where TGetPagedInput : IPagedResultRequest
        where TGetPagedOutput : IEntityDto<TPrimaryKey>
        where TGetUpdateOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : INullIdEntityDto
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
    }

    /// <summary>
    /// 应用程序服务基接口（基本方法：GetViewOutput,GetPaged,GetUpdateOutput,CreateInput,UpdateInput,GetUpdateInput,GetViewInput)
    /// </summary>
    public interface ICrudAsyncAppService<TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, in TGetPagedInput, TGetUpdateOutput, in TCreateInput, in TUpdateInput,
        in TGetUpdateInput, in TGetViewInput>
        : ICrudAsyncAppService<TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, TGetPagedInput, TGetUpdateOutput, TCreateInput, TUpdateInput,
         TGetUpdateInput, TGetViewInput, NullableIdDto<TPrimaryKey>, NullableIdDto<TPrimaryKey>, NullableIdDto<TPrimaryKey>>
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
    }

    /// <summary>
    /// 应用程序服务基接口（基本方法：GetViewOutput,GetPaged,GetUpdateOutput,CreateInput,UpdateInput,GetUpdateInput,GetViewInput,UpdateOutput,CreateOutput,DeleteInput)
    /// </summary>
    public interface ICrudAsyncAppService<TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, in TGetPagedInput, TGetUpdateOutput, in TCreateInput, in TUpdateInput,
        in TGetUpdateInput, in TGetViewInput, TUpdateOutput, TCreateOutput, in TDeleteInput>
        : IApplicationService
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
        Task<TGetUpdateOutput> GetUpdateAsync(TGetUpdateInput input);

        Task<TGetViewOutput> GetViewAsync(TGetViewInput input);

        Task<PagedResultDto<TGetPagedOutput>> GetPagedAsync(TGetPagedInput input);

        Task<TCreateOutput> CreateAsync(TCreateInput input);

        Task<TUpdateOutput> UpdateAsync(TUpdateInput input);

        Task DeleteAsync(TDeleteInput input);
    }
}
