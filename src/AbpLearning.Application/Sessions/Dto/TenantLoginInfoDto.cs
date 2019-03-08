namespace AbpLearning.Application.Sessions.Dto
{
    using Abp.Application.Services.Dto;

    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
