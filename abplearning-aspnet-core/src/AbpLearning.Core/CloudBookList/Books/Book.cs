namespace AbpLearning.Core.CloudBookList.Book
{
    using System.Collections.Generic;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using Relationships;

    /// <summary>
    /// 书籍
    /// </summary>
    public class Book : AuditedEntity<long>, IMustHaveTenant
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

        public int TenantId { get; set; }

        public IEnumerable<BookAndBookTagRelationship> BookAndBookTagRelationship { get; set; }

        public IEnumerable<BookListAndBookRelationship> BookListAndBookRelationship { get; set; }
    }
}
