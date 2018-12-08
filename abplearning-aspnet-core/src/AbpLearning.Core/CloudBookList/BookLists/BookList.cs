namespace AbpLearning.Core.CloudBookList.BookLists
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using Relationships;

    /// <summary>
    /// 书单
    /// </summary>
    public class BookList : AuditedEntity<long>, IMayHaveTenant
    {
        /// <summary>
        /// 书单名
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(128)]
        public string Intro { get; set; }

        /// <summary>
        /// 与书籍的关联
        /// </summary>
        public IEnumerable<BookListAndBookRelationship> BookListAndBookRelationships { get; set; }

        public int? TenantId { get; set; }
    }
}
