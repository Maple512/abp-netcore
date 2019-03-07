namespace AbpLearning.Web.Core.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.IO;
    using Abp.IO.Extensions;
    using Abp.UI;
    using AbpLearning.Application.Files;
    using AbpLearning.Application.Files.Model;
    using AbpLearning.Common;
    using AbpLearning.Core.Files.Folders;

    /// <summary>
    /// 文件
    /// </summary>
    public abstract class FileServiceControllerBase : AbpLearningControllerBase
    {
        /// <summary>
        /// 上传文件最大长度(MB)
        /// </summary>
        // private const int MaxProfilePictureSize = 1024 * 1024 * 1024 * 5;

        private readonly IFilesAppService _filesService;
        private readonly IAppFolderConfig _appFolderConfig;

        protected FileServiceControllerBase(IFilesAppService filesService, IAppFolderConfig appFolderConfig)
        {
            _filesService = filesService;
            _appFolderConfig = appFolderConfig;
        }

        /// <summary>
        /// 上传文件
        /// TODO:待优化
        /// </summary>
        /// <returns></returns>
        public async Task UploadFileAsync()
        {
            try
            {
                var profilePictureFile = Request.Form.Files.First();

                //Check input
                if (profilePictureFile == null)
                {
                    throw new UserFriendlyException(L("UploadFileIsEmpty"));
                }

                var fileLength = profilePictureFile.Length;
                //if (fileLength > MaxProfilePictureSize)
                //{
                //    throw new UserFriendlyException(L("UploadFileLengthExceedsMaxLength", MaxProfilePictureSize));
                //}

                byte[] fileBytes;
                using (var stream = profilePictureFile.OpenReadStream())
                {
                    fileBytes = stream.GetAllBytes();
                }

                var fileInfo = new FileInfo(profilePictureFile.FileName);

                var fileName = fileInfo.Name.Split('.')[0];

                // 存放文件夹：上传地址+时间戳
                var folder = _appFolderConfig.UploadFileFolder + Path.DirectorySeparatorChar + DateTimeHelper.GetDateString();
                DirectoryHelper.CreateIfNotExists(folder);

                var filePath = Path.Combine(folder, fileName + fileInfo.Extension);
                // 删除原文件
                FilesHelper.DeleteIfExsit(filePath);

                // 写入文件
                await System.IO.File.WriteAllBytesAsync(filePath, fileBytes);

                // 记录
                var uploadFile = new UploadFileEditModel(fileName, fileLength, folder, fileInfo.Extension.Replace(".", ""));
                await _filesService.InsertForUploadFileAsync(uploadFile);

                //using (var bmpImage = new Bitmap(tempFilePath))
                //{
                //    return new UploadProfilePictureOutputDto
                //    {
                //        FileName = tempFileName,
                //        Width = bmpImage.Width,
                //        Height = bmpImage.Height
                //    };
                //}
            }
            catch (UserFriendlyException ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }
    }
}
