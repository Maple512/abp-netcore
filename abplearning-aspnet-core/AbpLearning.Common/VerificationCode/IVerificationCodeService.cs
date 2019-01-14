namespace AbpLearning.Common.VerificationCode
{
    using System.IO;

    /// <summary>
    /// 验证码 服务 接口
    /// </summary>
    public interface IVerificationCodeService
    {
        MemoryStream Create(out string code, VerificationCodeType type = VerificationCodeType.Number, int length = 4);
    }
}
