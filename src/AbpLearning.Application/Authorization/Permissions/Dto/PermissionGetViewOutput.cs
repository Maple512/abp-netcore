namespace AbpLearning.Application.Authorization.Permissions.Dto
{
    using Base;

    public class PermissionGetViewOutput : INullIdEntityDto
    {
        /// <summary>
        /// parent node name
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// this role display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// this role discription
        /// </summary>
        public string Discription { get; set; }
    }
}
