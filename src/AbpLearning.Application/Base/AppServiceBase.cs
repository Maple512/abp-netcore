namespace AbpLearning.Application.Base
{
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Entities;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;

    /// <summary>
    /// 应用程序服务基类（实现：Paged,Sorting,Filtered）
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class AppServiceBase<TEntity, TPrimaryKey> : ApplicationService
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

        protected AppServiceBase(IRepository<TEntity, TPrimaryKey> repository)
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
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TGetPagedInput"></typeparam>
    public abstract class AppServiceBase<TEntity, TPrimaryKey, TGetPagedInput> : ApplicationService
        where TEntity : class, IEntity<TPrimaryKey>
        where TGetPagedInput : IPagedResultRequest
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

        /// <summary>
        /// Paged 权限
        /// </summary>
        protected virtual string GetPagedPermissionName { get; set; }

        /// <summary>
        /// Create 权限
        /// </summary>
        protected virtual string CreatePermissionName { get; set; }

        /// <summary>
        /// Update 权限
        /// </summary>
        protected virtual string UpdatePermissionName { get; set; }

        /// <summary>
        /// Delete 权限
        /// </summary>
        protected virtual string DeletePermissionName { get; set; }

        #endregion

        protected AppServiceBase(IRepository<TEntity, TPrimaryKey> repository)
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
            var sortInput = input as ISortedResultRequest;
            if (sortInput != null)
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
            var pagedInput = input as IPagedResultRequest;
            if (pagedInput != null)
            {
                return query.PageBy(pagedInput);
            }

            //Try to limit query result if available
            var limitedInput = input as ILimitedResultRequest;
            if (limitedInput != null)
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

        /// <summary>
        /// 检查 GetPaged 权限
        /// </summary>
        protected virtual void CheckGetPagedPermission()
        {
            CheckPermission(GetPagedPermissionName);
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
