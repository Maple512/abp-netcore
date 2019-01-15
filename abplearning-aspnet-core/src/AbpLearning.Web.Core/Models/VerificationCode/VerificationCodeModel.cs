namespace AbpLearning.Web.Core.Models.VerificationCode
{
    using System.ComponentModel.DataAnnotations;

    public class VerificationCodeModel
    {
        /// <summary>
        /// 验证码key
        /// </summary>
        [Required]
        public string CacheKey { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        public string VerificationCode { get; set; }

        public int? TenantId { get; set; }
    }
}
