namespace AbpLearning.Common
{
    using System.IO;

    public static class FilesHelper
    {
        /// <summary>
        /// 删除文件（如果存在）
        /// </summary>
        /// <param name="fullName">绝对路径</param>
        public static void DeleteIfExsit(string fullName)
        {
            if (File.Exists(fullName))
            {
                File.Delete(fullName);
            }
        }
    }
}
