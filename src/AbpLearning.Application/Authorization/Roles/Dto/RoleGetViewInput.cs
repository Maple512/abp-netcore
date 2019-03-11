namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using Abp.Application.Services.Dto;

    public class RoleGetViewInput : EntityDto<int>
    {
        /// <summary>
        /// Permission Name
        /// </summary>
        public string PermissionName { get; set; }
    }
}
