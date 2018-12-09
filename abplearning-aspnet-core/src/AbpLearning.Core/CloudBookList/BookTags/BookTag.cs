namespace AbpLearning.Core.CloudBookList.BookTags
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using AbpLearning.Core.Authorization.Users;
    using Relationships;

    /// <summary>
    /// 书籍标签
    /// </summary>
    public class BookTag : AuditedEntity<long, User>, IMayHaveTenant
    {
        public BookTag(string name, int? tenantId = null)
        {
            Name = name;
            TenantId = tenantId;
        }

        /// <summary>
        /// 标签名
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string Name { get; set; }

        public int? TenantId { get; set; }

        public virtual IEnumerable<BookAndBookTagRelationship> BookAndBookTagRelationships { get; set; }
    }
}
