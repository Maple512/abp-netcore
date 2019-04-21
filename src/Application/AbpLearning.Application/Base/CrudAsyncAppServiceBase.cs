namespace AbpLearning.Application.Base
{
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Entities;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
    using AbpLearning.Core;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 应用程序服务基类（实现：Paged,Sorting,Filtered）
    /// 注：必须重写 PermissionName 属性（PermissionName默认为空）
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class CrudAsyncAppServiceBase<TEntity, TPrimaryKey> : AbpLearningAppServiceBase
        where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Repository
        /// </summary>
        protected readonly IRepository<TEntity, TPrimaryKey> Repository;

        #region Permission Name

        /// <summary>
        /// Get 权限
        /// </summary>
        protected virtual string GetPermissionName { get; set; }

        #endregion

        protected CrudAsyncAppServiceBase(IRepository<TEntity, TPrimaryKey> repository)
        {
            Repository = repository;
        }

        #region Check Permission

        /// <summary>
        /// 检查权限
        /// </summary>
        /// <param name="permissionName">权限名</param>
        protected virtual void CheckPermission(string permissionName)
        {
            if (!string.IsNullOrEmpty(permissionName))
            {
                PermissionChecker.Authorize(permissionName);
            }
        }

        /// <summary>
        /// 检查 Get 权限
        /// </summary>
        protected virtual void CheckGetPermission()
        {
            CheckPermission(GetPermissionName);
        }

        #endregion
    }

    /// <summary>
    /// 应用程序服务基类（实现：Paged,Sorting,Filtered）
    /// 注：必须重写 PermissionName 属性（PermissionName默认为空）
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TGetPagedInput"></typeparam>
    public abstract class CrudAsyncAppServiceBase<TEntity, TPrimaryKey, TGetPagedInput> : AbpLearningAppServiceBase
            where TEntity : class, IEntity<TPrimaryKey>
            where TGetPagedInput : IPagedResultRequest
    {
        /// <summary>
        /// Repository
        /// </summary>
        protected readonly IRepository<TEntity, TPrimaryKey> Repository;

        /// <summary>
        /// Repository GetAll AsNoTracking
        /// </summary>
        protected IQueryable<TEntity> Entities => Repository.GetAll().AsNoTracking();

        #region Permission Name

        protected abstract string NodePermissionName { get; }

        /// <summary>
        /// Get 权限
        /// </summary>
        protected virtual string QueryPermissionName => NodePermissionName + AbpLearningPermissions.Action.Query;

        /// <summary>
        /// Create 权限
        /// </summary>
        protected virtual string CreatePermissionName => NodePermissionName + AbpLearningPermissions.Action.Create;

        /// <summary>
        /// Update 权限
        /// </summary>
        protected virtual string UpdatePermissionName => NodePermissionName + AbpLearningPermissions.Action.Update;

        /// <summary>
        /// Delete 权限
        /// </summary>
        protected virtual string DeletePermissionName => NodePermissionName + AbpLearningPermissions.Action.Delete;

        #endregion

        protected CrudAsyncAppServiceBase(IRepository<TEntity, TPrimaryKey> repository)
        {
            Repository = repository;
        }

        #region Paged Sorting Filtered

        /// <summary>
        /// 应用排序
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="input">The input.</param>
        protected virtual IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, TGetPagedInput input)
        {
            //Try to sort query if available
            if (input is ISortedResultRequest sortInput)
            {
                if (!sortInput.Sorting.IsNullOrWhiteSpace())
                {
                    return query.OrderBy(sortInput.Sorting);
                }
            }

            //IQueryable.Task requires sorting, so we should sort if Take will be used.
            if (input is ILimitedResultRequest)
            {
                return query.OrderByDescending(e => e.Id);
            }

            //No sorting
            return query;
        }

        /// <summary>
        /// 应用分页
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="input">The input.</param>
        protected virtual IQueryable<TEntity> ApplyPaging(IQueryable<TEntity> query, TGetPagedInput input)
        {
            //Try to use paging if available
            if (input is IPagedResultRequest pagedInput)
            {
                return query.PageBy(pagedInput);
            }

            //Try to limit query result if available
            if (input is ILimitedResultRequest limitedInput)
            {
                return query.Take(limitedInput.MaxResultCount);
            }

            //No paging
            return query;
        }

        /// <summary>
        /// 创建查询过滤（不进行排序与分页）
        /// </summary>
        /// <param name="input">The input.</param>
        protected virtual IQueryable<TEntity> CreateFilteredQuery(TGetPagedInput input)
        {
            return Repository.GetAll();
        }

        #endregion

        #region Check Permission

        /// <summary>
        /// 检查权限
        /// </summary>
        /// <param name="permissionName">权限名</param>
        protected virtual void CheckPermission(string permissionName)
        {
            // PermissionChecker.Authorize(permissionName);
        }

        /// <summary>
        /// 检查 Get 权限
        /// </summary>
        protected virtual void CheckGetPermission()
        {
            CheckPermission(QueryPermissionName);
        }

        /// <summary>
        /// 检查 GetPaged 权限
        /// </summary>
        protected virtual void CheckGetPagedPermission()
        {
            CheckPermission(QueryPermissionName);
        }

        /// <summary>
        /// 检查 Create 权限
        /// </summary>
        protected virtual void CheckCreatePermission()
        {
            CheckPermission(CreatePermissionName);
        }

        /// <summary>
        /// 检查 Update 权限
        /// </summary>
        protected virtual void CheckUpdatePermission()
        {
            CheckPermission(UpdatePermissionName);
        }

        /// <summary>
        /// 检查 Delete 权限
        /// </summary>
        protected virtual void CheckDeletePermission()
        {
            CheckPermission(DeletePermissionName);
        }

        #endregion
    }
}
