namespace AbpLearning.Core.CloudBookList.Relationships
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using BookLists;

    /// <summary>
    /// 书单 关联 书籍
    /// </summary>
    public class BookListAndBookRelationship : AuditedEntity<long>, IMayHaveTenant
    {
        [Required]
        public long BookListId { get; set; }

        /// <summary>
        /// 书单
        /// </summary>
        [ForeignKey(nameof(BookListId))]
        public BookList BookList { get; set; }

        [Required]
        public long BookId { get; set; }

        /// <summary>
        /// 书籍
        /// </summary>
        [ForeignKey(nameof(BookId))]
        public Books.Book Book { get; set; }

        public int? TenantId { get; set; }
    }
}
