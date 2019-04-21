namespace AbpLearning.Web.Core.Authentication.External
{
    public class ExternalAuthUserInfo
    {
        public string ProviderKey { get; set; }

        public string Provider { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public string AvatarUrl { get; set; }
    }
}
