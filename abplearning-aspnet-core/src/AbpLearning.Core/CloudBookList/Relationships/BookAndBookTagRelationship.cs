namespace AbpLearning.Core.CloudBookList.Relationships
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using BookTags;

    /// <summary>
    /// 书籍 关联 书籍标签
    /// </summary>
    public class BookAndBookTagRelationship : AuditedEntity<long>, IMayHaveTenant
    {
        [Required]
        public long BookId { get; set; }

        /// <summary>
        /// 书籍
        /// </summary>
        [ForeignKey(nameof(BookId))]
        public Books.Book Book { get; set; }

        [Required]
        public long BookTagId { get; set; }

        /// <summary>
        /// 书籍标签
        /// </summary>
        [ForeignKey(nameof(BookTagId))]
        public BookTag BookTag { get; set; }

        public int? TenantId { get; set; }
    }
}
