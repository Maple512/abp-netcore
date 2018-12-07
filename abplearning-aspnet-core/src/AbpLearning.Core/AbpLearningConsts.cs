namespace AbpLearning.Core
{
    public class AbpLearningConsts
    {
        public const string LocalizationSourceName_Application = "AbpLearning";
        public const string LocalizationSourceName_Core = "AbpLearning";
        public const string LocalizationSourceName_WebCore = "AbpLearning";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;

        /// <summary>
        /// 分页模型中，返回的默认数量
        /// </summary>
        public const int DefaultResultCount = 10;

        /// <summary>
        /// 分页模型中，返回的最大数量
        /// </summary>
        public const int MaxResultCount = 100;
    }
}
