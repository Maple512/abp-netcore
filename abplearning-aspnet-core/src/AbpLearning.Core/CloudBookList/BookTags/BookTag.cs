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
        public BookTag(string name, string color = null, int? tenantId = null)
        {
            Name = name;
            TenantId = tenantId;
            Color = color;
        }

        /// <summary>
        /// 标签名
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string Name { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        [MaxLength(10)]
        [DataType(DataType.Text)]
        public string Color { get; set; }

        public int? TenantId { get; set; }

        public virtual IEnumerable<BookAndBookTagRelationship> BookAndBookTagRelationships { get; set; }
    }
}
