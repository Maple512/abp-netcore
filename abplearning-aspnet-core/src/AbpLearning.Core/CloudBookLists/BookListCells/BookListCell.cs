namespace AbpLearning.Core.CloudBookLists.BookListCells
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities;

    /// <summary>
    /// 书单格子（1个格子，最多可以放一本书）
    /// </summary>
    [Table(AbpLearningConsts.TablePreFixName.CloudBookList + nameof(BookListCell), Schema = AbpLearningConsts.TableSchemaName.CloudBookList)]
    public class BookListCell : Entity<long>, IMayHaveTenant, ISoftDelete
    {
        /// <summary>
        /// 排序
        /// </summary>
        public byte Sort { get; set; }

        /// <summary>
        /// 书籍（可空）
        /// </summary>
        public long? BookId { get; set; }

        public long BookListId { get; set; }

        public int? TenantId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
