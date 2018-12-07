using Abp.AutoMapper;
using AbpLearning.Web.Core.Authentication.External;

namespace AbpLearning.Web.Core.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
