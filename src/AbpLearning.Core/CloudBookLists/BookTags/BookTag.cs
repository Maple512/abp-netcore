namespace AbpLearning.Core.CloudBookLists.BookTags
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities;

    /// <summary>
    /// 书籍标签
    /// </summary>
    [Table(AbpLearningConsts.TablePreFixName.CloudBookList + nameof(BookTag), Schema = AbpLearningConsts.TableSchemaName.CloudBookList)]
    public class BookTag : Entity<long>, IMayHaveTenant, ISoftDelete
    {
        public BookTag(string name, string color, int? tenantId = null, bool isDeleted = false)
        {
            Name = name;
            TenantId = tenantId;
            Color = color;
            IsDeleted = isDeleted;
        }

        /// <summary>
        /// 标签名（不能重复）
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string Name { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        [Required]
        [MaxLength(7)]
        public string Color { get; set; }

        public long BookId { get; set; }

        public int? TenantId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
