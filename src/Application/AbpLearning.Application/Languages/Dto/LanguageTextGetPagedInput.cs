namespace AbpLearning.Application.Languages.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Extensions;
    using Abp.Localization;
    using AbpLearning.Application.Base;

    /// <summary>
    /// 语言文本分页 输入模型
    /// </summary>
    public class LanguageTextGetPagedInput : PagedFilteringDtoBase
    {
        /// <summary>
        /// 本地化
        /// </summary>
        [Required]
        [MaxLength(ApplicationLanguageText.MaxSourceNameLength)]
        public string SourceName { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [Required]
        [StringLength(maximumLength:ApplicationLanguage.MaxNameLength)]
        public string LanguageName { get; set; }

        /// <summary>
        /// 对比语言
        /// </summary>
        [StringLength(maximumLength: ApplicationLanguage.MaxNameLength)]
        public string ContrastLanguageName { get; set; }

        /// <summary>
        /// 值过滤 类型
        /// </summary>
        public TargetValueFilterEnum TargetValueFilter { get; set; }

        public override void Normalize()
        {
            if (Sorting.IsNullOrEmpty())
            {
                Sorting = "Key ASC";
            }
        }

        /// <summary>
        /// 值过滤 类型
        /// </summary>
        public enum TargetValueFilterEnum
        {
            /// <summary>
            /// 全部
            /// </summary>
            All = 1,

            /// <summary>
            /// 为空
            /// </summary>
            Empty
        }
    }
}
