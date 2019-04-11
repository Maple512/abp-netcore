namespace AbpLearning.Core
{
    public static class AbpLearningCoreConfig
    {
        public const string LOCALIZATION_SOURCE_NAME = "AbpLearning";

        public const string CONNECTION_STRING_NAME = "Default";

        public const bool MULTI_TENANCY_ENABLED = false;

        /// <summary>
        /// 分页模型中，返回的默认数量
        /// </summary>
        public const int DEFAULT_RESULT_COUNT = 10;

        /// <summary>
        /// 分页模型中，返回的最大数量
        /// </summary>
        public const int MAX_RESULT_COUNT = 100;
    }
}
