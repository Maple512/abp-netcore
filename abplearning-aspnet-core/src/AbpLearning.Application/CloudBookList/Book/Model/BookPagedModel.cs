namespace AbpLearning.Application.CloudBookList.Book.Model
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Entities.Auditing;

    public class BookPagedModel : EntityDto<long>, IHasModificationTime
    {
        /// <summary>
        /// 封面图片URL
        /// </summary>
        public string CoverImgUrl { get; set; }

        /// <summary>
        /// 书名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }

        public DateTime CreationTime { get; set; }

        public string TenancyDisplayName { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
