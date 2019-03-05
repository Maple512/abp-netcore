namespace AbpLearning.Core.Files.Folders
{
    /// <summary>
    /// APP文件路径配置
    /// </summary>
    public interface IAppFolderConfig
    {
        /// <summary>
        /// 上传文件地址
        /// </summary>
        string UploadFileFolder { get; set; }

        /// <summary>
        /// 用户头像地址
        /// </summary>
        string UploadUserPortrait { get; set; }

        /// <summary>
        /// wootroot 地址
        /// </summary>
        string WebRootPath { get; set; }
    }
}
