namespace AbpLearning.Application.Roles
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using Abp.UI;
    using Core;
    using Core.Authorization.Roles;
    using Core.Authorization.Users;
    using Microsoft.EntityFrameworkCore;
    using Model;

    [AbpAuthorize(AbpLearningPermissions.Role)]
    public class RoleAppService : AbpLearningAppServiceBase, IRoleAppService<int>
    {
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;
        private readonly IRepository<Role> _repository;

        public RoleAppService(IRepository<Role> repository,RoleManager roleManager, UserManager userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _repository = repository;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Create(RoleEditModel model)
        {
            var role = ObjectMapper.Map<Role>(model);
            role.SetNormalizedName();

            CheckErrors(await _roleManager.CreateAsync(role));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Update(RoleEditModel model)
        {
            var role = await _roleManager.GetRoleByIdAsync(model.Id);

            ObjectMapper.Map(model, role);

            CheckErrors(await _roleManager.UpdateAsync(role));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Delete(EntityDto<int> model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id.ToString());

            if (role.IsStatic)
            {
                throw new UserFriendlyException(L("This role cannot be deleted"));
            }

            var users = await _userManager.GetUsersInRoleAsync(role.NormalizedName);

            foreach (var user in users)
            {
                CheckErrors(await _userManager.RemoveFromRoleAsync(user, role.NormalizedName));
            }

            CheckErrors(await _roleManager.DeleteAsync(role));
        }

        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        public Task<ListResultDto<PermissionViewModel>> GetAllPermissions()
        {
            var permissions = PermissionManager.GetAllPermissions();

            return Task.FromResult(new ListResultDto<PermissionViewModel>(
                ObjectMapper.Map<List<PermissionViewModel>>(permissions)
            ));
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<RolePagedModel>> GetPaged(RolePagedFilteringModel filter)
        {
            var query = _roleManager.Roles
                .WhereIf(!filter.Name.IsNullOrWhiteSpace(), m => m.Name.Contains(filter.Name))
                .WhereIf(filter.PermissionNames?.Count > 0, m => m.Permissions.Any(p => filter.PermissionNames.Contains(p.Name) && p.IsGranted));

            var count = await query.CountAsync();

            var roles = await query.OrderBy(filter.Sorting).PageBy(filter).ToListAsync();

            return new PagedResultDto<RolePagedModel>(count, ObjectMapper.Map<List<RolePagedModel>>(roles));
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<EntityDto<int>> entities)
        {
            foreach (var entity in entities)
            {
                await Delete(entity);
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<RoleEditModel> GetEdit(NullableIdDto<int> entity)
        {
            var editModel = new RoleEditModel();

            if (entity.Id.HasValue)
            {
                var role = await _roleManager.GetRoleByIdAsync(entity.Id.Value);

                editModel = role.MapTo<RoleEditModel>();
            }

            return editModel;
        }

        /// <summary>
        /// 更新角色的权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdatePermissionsForRole(PermissionEditModel model)
        {
            var role = await _roleManager.GetRoleByIdAsync(model.RoleId);

            var grantedPermissions = PermissionManager
                .GetAllPermissions()
                .Where(p => model.Permissions.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }
    }
}
