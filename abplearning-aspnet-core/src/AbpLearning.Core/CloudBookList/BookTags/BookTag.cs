namespace AbpLearning.Core.CloudBookList.BookTags
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using Relationships;

    /// <summary>
    /// 书籍标签
    /// </summary>
    public class BookTag : AuditedEntity<long>, IMayHaveTenant
    {
        /// <summary>
        /// 标签名
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string Name { get; set; }

        /// <summary>
        /// 与书籍的关联
        /// </summary>
        public IEnumerable<BookAndBookTagRelationship> BookAndBookTagRelationships { get; set; }

        public int? TenantId { get; set; }
    }
}
