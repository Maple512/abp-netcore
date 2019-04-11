namespace AbpLearning.Application.Security.VerificationCodes
{
    using System.Threading.Tasks;
    using AbpLearning.Application.Security.VerificationCodes.model;

    public interface IVerificationCodeAppService
    {
        /// <summary>
        /// 校验 验证码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task ChecekVierificationCode(VerificationCodeModel model);
    }
}
