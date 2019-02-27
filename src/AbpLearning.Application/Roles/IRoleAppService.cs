namespace AbpLearning.Application.Roles
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Model;

    public interface IRoleAppService<TPrimaryKey> : IApplicationService
    where TPrimaryKey: struct
    {
        /// <summary>
        /// 所有权限
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<PermissionViewModel>> GetAllPermissions();

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="filter">分页过滤模型</param>
        /// <returns></returns>
        Task<PagedResultDto<RolePagedModel>> GetPaged(RolePagedFilteringModel filter);

        /// <summary>
        /// 获取更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<RoleEditModel> GetEdit(NullableIdDto<TPrimaryKey> entity);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Create(RoleEditModel input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Update(RoleEditModel input);

        /// <summary>
        /// 更新角色权限
        /// </summary>
        /// <returns></returns>
        Task UpdatePermissionsForRole(PermissionEditModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<TPrimaryKey> input);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task BatchDelete(List<EntityDto<TPrimaryKey>> entities);
    }
}
