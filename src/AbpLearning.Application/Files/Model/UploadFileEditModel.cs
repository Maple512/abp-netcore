namespace AbpLearning.Application.Files.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using AbpLearning.Core.Files;

    [AutoMapTo(typeof(UploadFile))]
    public class UploadFileEditModel : NullableIdDto<Guid>
    {
        public const byte FileNameMaxLenght = UploadFile.FileNameMaxLenght;

        /// <summary>
        /// 文件名
        /// </summary>
        [Required]
        [Range(1, FileNameMaxLenght)]
        public string Name { get; set; }

        /// <summary>
        /// 文件大小(kb)
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 存储路径
        /// </summary>
        [Required]
        public string StoragePath { get; set; }

        /// <summary>
        /// 后缀
        /// </summary>
        public string Extension { get; set; }
    }
}
