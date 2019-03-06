namespace AbpLearning.Core.Files.Folders
{
    using Abp.Dependency;

    /// <summary>
    /// APP文件路径配置
    /// </summary>
    public class AppFolderConfig : IAppFolderConfig, ISingletonDependency
    {
        /// <summary>
        /// 上传文件地址（存放地址，虚拟路径）
        /// </summary>
        public string UploadFileFolder { get; set; }

        /// <summary>
        /// 用户头像地址（存放地址，虚拟路径）
        /// </summary>
        public string UploadUserPortrait { get; set; }

        /// <summary>
        /// wootroot 地址
        /// </summary>
        public string WebRootPath { get; set; }

        /// <summary>
        /// 站点URL
        /// </summary>
        public string WebURL { get; set; }
    }
}
