namespace AbpLearning.Application.Sessions.Dto
{
    using Abp.Application.Services.Dto;

    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
