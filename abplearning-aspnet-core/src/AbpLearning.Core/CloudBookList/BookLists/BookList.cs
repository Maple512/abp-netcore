namespace AbpLearning.Core.CloudBookList.BookLists
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using AbpLearning.Core.Authorization.Users;
    using Relationships;

    /// <summary>
    /// 书单
    /// </summary>
    public class BookList : AuditedEntity<long, User>, IMayHaveTenant
    {
        public BookList(string name, string intro = null, int? tenantId = null)
        {
            Name = name;
            Intro = intro;
            TenantId = tenantId;
        }

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

        public int? TenantId { get; set; }

        public virtual IEnumerable<BookListAndBookRelationship> BookListAndBookRelationships { get; set; }
    }
}
