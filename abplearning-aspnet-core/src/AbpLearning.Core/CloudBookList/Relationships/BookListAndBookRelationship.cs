namespace AbpLearning.Core.CloudBookList.Relationships
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using Authorization.Users;
    using BookLists;

    /// <summary>
    /// 书单 关联 书籍
    /// </summary>
    public class BookListAndBookRelationship : AuditedEntity<long, User>, IMayHaveTenant
    {
        public BookListAndBookRelationship(long bookListId, long bookId, int? tenantId = null)
        {
            BookListId = bookListId;
            BookId = bookId;
            TenantId = tenantId;
        }

        [Required]
        public long BookListId { get; set; }

        /// <summary>
        /// 书单
        /// </summary>
        [ForeignKey(nameof(BookListId))]
        public virtual BookList BookList { get; set; }

        [Required]
        public long BookId { get; set; }

        /// <summary>
        /// 书籍
        /// </summary>
        [ForeignKey(nameof(BookId))]
        public virtual Books.Book Book { get; set; }

        public int? TenantId { get; set; }
    }
}
