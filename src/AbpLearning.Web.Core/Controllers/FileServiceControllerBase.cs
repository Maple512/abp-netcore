namespace AbpLearning.Web.Core.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.IO.Extensions;
    using Abp.UI;
    using AbpLearning.Application.Files;
    using AbpLearning.Application.Files.Model;

    /// <summary>
    /// 文件
    /// </summary>
    public abstract class FileServiceControllerBase : AbpLearningControllerBase
    {
        /// <summary>
        /// 上传文件最大长度(KB)
        /// </summary>
        private const int MaxProfilePictureSize = 1024 * 5;

        private readonly IFilesAppService _filesService;

        public FileServiceControllerBase(IFilesAppService filesService)
        {
            _filesService = filesService;
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

                var fileLength = profilePictureFile.Length / 1024;
                if (fileLength > MaxProfilePictureSize)
                {
                    throw new UserFriendlyException(L("UploadFileLengthExceedsMaxLength", $"{MaxProfilePictureSize / 1024}M"));
                }

                byte[] fileBytes;
                using (var stream = profilePictureFile.OpenReadStream())
                {
                    fileBytes = stream.GetAllBytes();
                }

                //if (!ImageFormatHelper.GetRawImageFormat(fileBytes).IsIn(ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Gif))
                //{
                //    throw new Exception("Uploaded file is not an accepted image file !");
                //}

                // Delete old temp profile pictures
                // AppFileHelper.DeleteFilesInFolderIfExists(_appFolder.TempFileDownloadFolder, "userProfileImage_" + AbpSession.GetUserId());

                //Save new picture
                var fileInfo = new FileInfo(profilePictureFile.FileName);

                var fileName = fileInfo.Name.Split('.')[0] + "_" + AbpSession.UserId;
                var folder = @"D:/AbpLearning_File";
                var filePath = Path.Combine(folder, fileName + fileInfo.Extension);

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
                await Task.Run(null);
            }
        }
    }
}
