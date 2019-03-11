namespace AbpLearning.Application.Authorization.Permissions.Dto
{
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Base;

    [AutoMapFrom(typeof(Permission))]
    public class PermissionGetViewOutput : INullIdEntityDto
    {
        /// <summary>
        /// parent node name
        /// </summary>
        public string ParentName { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// this role display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// this role description
        /// </summary>
        public string Description { get; set; }
    }
}
