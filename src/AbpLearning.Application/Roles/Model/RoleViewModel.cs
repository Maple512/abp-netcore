namespace AbpLearning.Application.Roles.Model
{
    public class RoleViewModel
    {
        public string Name { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Description { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }
    }
}
