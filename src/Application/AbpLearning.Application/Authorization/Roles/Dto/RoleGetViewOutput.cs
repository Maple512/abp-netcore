namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using AbpLearning.Core.Authorization.Roles;

    [AutoMapFrom(typeof(Role))]
    public class RoleGetViewOutput : NullableIdDto
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }
    }
}
