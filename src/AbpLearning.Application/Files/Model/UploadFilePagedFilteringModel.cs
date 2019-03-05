namespace AbpLearning.Application.Files.Model
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.Extensions;
    using Abp.Runtime.Validation;

    public class UploadFilePagedFilteringModel : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 上传时间-开始
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 上传时间-结束
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public int? FileType { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrEmpty())
            {
                Sorting = "CreationTime Desc";
            }
        }
    }
}
