namespace AbpLearning.Core.Files
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities.Auditing;

    /// <summary>
    /// 上传文件（Entity）
    /// </summary>
    [Table(AbpLearningConsts.TablePreFixName.File + nameof(UploadFile), Schema = AbpLearningConsts.TableSchemaName.File)]
    public class UploadFile : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 最大文件名长度
        /// </summary>
        public const byte FileNameMaxLenght = 64;

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

        /// <summary>
        /// 下载次数
        /// </summary>
        public int DownloadCount { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public int? FileType { get; set; }

        [ForeignKey(nameof(FileType))]
        public virtual FileType TypeName { get; set; }
    }
}
