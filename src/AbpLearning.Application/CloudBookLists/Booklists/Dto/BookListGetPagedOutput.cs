namespace AbpLearning.Application.CloudBookLists.BookLists.Dto
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Entities.Auditing;

    public class BookListGetPagedOutput : EntityDto<long>, IHasModificationTime
    {
        /// <summary>
        /// 书单名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        /// 书单中存在多少本书籍
        /// </summary>
        public int ExsitedBookCount { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
