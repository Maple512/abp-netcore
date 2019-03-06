namespace AbpLearning.Application.Roles.Model
{
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;
    using Abp.Extensions;
    using Abp.Runtime.Validation;

    /// <summary>
    /// <see cref="RolePagedModel"/> 过滤/排序 模型
    /// </summary>
    public class RolePagedFilteringModel : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 拥有的权限
        /// </summary>
        public List<string> PermissionNames { get; set; }

        /// <summary>
        /// 权限名
        /// </summary>
        public string Name { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrEmpty())
            {
                Sorting = "Name";
            }
        }
    }
}
