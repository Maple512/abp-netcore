namespace AbpLearning.Core.CloudBookList.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using Relationships;

    /// <summary>
    /// 书籍
    /// </summary>
    public class Book : AuditedEntity<long>, IMayHaveTenant
    {
        /// <summary>
        /// 封面图片URL
        /// </summary>
        [MaxLength(128)]
        public string CoverImgUrl { get; set; }

        /// <summary>
        /// 书名
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Author { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(128)]
        public string Intro { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        [MaxLength(128)]
        public string Url { get; set; }

        public int? TenantId { get; set; }

        public IEnumerable<BookAndBookTagRelationship> BookAndBookTagRelationship { get; set; }

        public IEnumerable<BookListAndBookRelationship> BookListAndBookRelationship { get; set; }
    }
}
