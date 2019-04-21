namespace AbpLearning.Application.Languages.Dto
{
    /// <summary>
    /// 语言文本分页 输出模型
    /// </summary>
    public class LanguageTextGetPagedOutput
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 对比值
        /// </summary>
        public string ContrastValue { get; set; }
    }
}
