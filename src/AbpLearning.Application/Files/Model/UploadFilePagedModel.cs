namespace AbpLearning.Application.Files.Model
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Entities.Auditing;

    public class UploadFilePagedModel : EntityDto<Guid>, IHasModificationTime
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件大小(bytes)
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// 后缀
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string Type { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
