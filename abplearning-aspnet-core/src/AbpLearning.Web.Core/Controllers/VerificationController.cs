namespace AbpLearning.Web.Core.Controllers
{
    using Abp.Runtime.Caching;
    using Common.VerificationCode;

    public class VerificationController:AbpLearningControllerBase
    {
        private readonly IVerificationCodeService _codeService;

        private readonly ICacheManager _cacheManager;

        public VerificationController(IVerificationCodeService codeService, ICacheManager cacheManager)
        {
            _codeService = codeService;
            _cacheManager = cacheManager;
        }

        // TODO:验证码
    }
}
