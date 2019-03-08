namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using Base;

    public class RoleGetViewOutput: INullIdEntityDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }
    }
}
