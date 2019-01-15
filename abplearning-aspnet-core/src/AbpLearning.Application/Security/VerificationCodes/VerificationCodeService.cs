namespace AbpLearning.Application.Security.VerificationCodes
{
    using System.Threading.Tasks;
    using Abp.Configuration;
    using Abp.Extensions;
    using Abp.Runtime.Caching;
    using Common.Extensions;

    public static class VerificationCodeService
    {
        public const string NotValidVerificationCode = "NotValidVerificationCode";
        public const string VerificationCodeExpired = "VerificationCodeExpired";
        public const string NotMatchVerificationCode = "NotMatchVerificationCode";
        public const string NotActiveVerificationCode = "NotActiveVerificationCode";
        public static string Successfull = string.Empty;

        public static async Task<string> CheckVerificationCode(ICacheManager cacheManager, ISettingManager settingManager, string cacheKey, string verificationCode, int? tenantId = null)
        {
            // TODO:是否启用验证码
            if (true)
            {
                if (verificationCode.IsNullOrWhiteSpace())
                {
                    return NotValidVerificationCode;
                }

                // 分租户获取验证码缓存
                var key = "VerificationCode_Cache_Key";

                // 从缓存验证码值
                var cacheValue = await cacheManager.GetValue<string>(key, cacheKey, true);

                // 过期
                if (cacheValue.IsNullOrWhiteSpace())
                {
                    return VerificationCodeExpired;
                }

                // 对比
                if (verificationCode.ToLower() != cacheValue)
                {
                    return NotMatchVerificationCode;
                }

                return Successfull;
            }

            return NotActiveVerificationCode;
        }
    }
}
