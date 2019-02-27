namespace AbpLearning.Common.VerificationCode
{
    /// <summary>
    /// 验证码类型
    /// </summary>
    public enum VerificationCodeType
    {
        /// <summary>
        /// 纯数字
        /// </summary>
        Number,

        /// <summary>
        /// 纯字母
        /// </summary>
        Letter,

        /// <summary>
        /// 数字+字母
        /// </summary>
        NumberAndLetter,

        /// <summary>
        /// 汉字
        /// </summary>
        Hanzi,
    }
}
