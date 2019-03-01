namespace AbpLearning.Application.Files.Model
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using AbpLearning.Core.Files;

    [AutoMapFrom(typeof(UploadFile))]
    public class UploadFilePagedModel : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件大小(kb)
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
    }
}
