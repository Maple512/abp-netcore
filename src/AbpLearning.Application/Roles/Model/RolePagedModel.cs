namespace AbpLearning.Application.Roles.Model
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Abp.Domain.Entities.Auditing;
    using AbpLearning.Core.Authorization.Roles;

    /// <summary>
    /// <see cref="Role" /> 分页模型
    /// </summary>
    /// <inheritdoc cref="IHasModificationTime" />
    [AutoMapFrom(typeof(Role))]
    public class RolePagedModel : EntityDto<long>, IHasModificationTime
    {
        /// <summary>
        /// 是否静态角色（系统管理员角色，不能删除）
        /// </summary>
        public bool IsStatic { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 是否默认角色（新用户默认拥有）
        /// </summary>
        public bool IsDefault { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
