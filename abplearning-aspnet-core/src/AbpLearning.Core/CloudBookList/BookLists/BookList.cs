namespace AbpLearning.Core.CloudBookList.BookLists
{
    using System.Collections.Generic;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using Relationships;

    /// <summary>
    /// 书单
    /// </summary>
    public class BookList : AuditedEntity<long>, IMustHaveTenant
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
        /// 与书籍的关联
        /// </summary>
        public IEnumerable<BookListAndBookRelationship> BookListAndBookRelationships { get; set; }

        public int TenantId { get; set; }
    }
}
