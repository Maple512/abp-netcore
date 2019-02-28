namespace AbpLearning.Web.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.IO.Extensions;
    using Abp.UI;
    using AbpLearning.Application.Files;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 文件
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class FilesController : AbpLearningControllerBase
    {
        /// <summary>
        /// 上传文件最大长度
        /// </summary>
        private const int MaxProfilePictureSize = 1024 * 1024 * 5;

        private readonly IFilesAppService _filesService;

        public FilesController(IFilesAppService filesService)
        {
            _filesService = filesService;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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

                if (profilePictureFile.Length > MaxProfilePictureSize)
                {
                    throw new UserFriendlyException(L("UploadFileLengthExceedsMaxLength", $"{MaxProfilePictureSize / 1024 / 1024}M"));
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
                //var fileInfo = new FileInfo(profilePictureFile.FileName);
                //var tempFileName = "userProfileImage_" + AbpSession.GetUserId() + fileInfo.Extension;
                //var tempFilePath = Path.Combine(_appFolder.TempFileDownloadFolder, tempFileName);
                //System.IO.File.WriteAllBytes(tempFilePath, fileBytes);

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
