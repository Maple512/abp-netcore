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
        /// 
        /// </summary>
        /// <param name="name">文件名</param>
        /// <param name="size">文件大小(kb)</param>
        /// <param name="storagePath">存储路径（虚拟路径）</param>
        /// <param name="extension">文件后缀</param>
        public UploadFileEditModel(string name, long size, string storagePath, string extension)
        {
            Name = name;
            Size = size;
            StoragePath = storagePath;
            Extension = extension;
        }

        /// <summary>
        /// 文件名
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 文件大小(bytes)
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// 存储路径（虚拟路径）
        /// </summary>
        [Required]
        public string StoragePath { get; set; }

        /// <summary>
        /// 后缀
        /// </summary>
        public string Extension { get; set; }
    }
}
