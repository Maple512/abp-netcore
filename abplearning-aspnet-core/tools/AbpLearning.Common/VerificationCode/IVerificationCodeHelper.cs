namespace AbpLearning.Common.VerificationCode
{
    using System.IO;
    using Abp.Dependency;

    /// <summary>
    /// 验证码 工具 接口
    /// </summary>
    public interface IVerificationCodeHelper : ISingletonDependency
    {
        MemoryStream Create(out string code, VerificationCodeType type = VerificationCodeType.Number, int length = 4);
    }
}
