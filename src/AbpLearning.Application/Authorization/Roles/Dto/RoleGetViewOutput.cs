namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using Abp.AutoMapper;
    using AbpLearning.Core.Authorization.Roles;
    using Base;

    [AutoMapFrom(typeof(Role))]
    public class RoleGetViewOutput : INullIdEntityDto
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }
    }
}
