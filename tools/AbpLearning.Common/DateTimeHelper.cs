namespace AbpLearning.Common
{
    using System;

    public static class DateTimeHelper
    {
        public static string GetTimeStamp()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 日期字符串（无间隔） yyyyMMdd
        /// </summary>
        /// <returns></returns>
        public static string GetDateString()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }
    }
}
