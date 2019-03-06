namespace AbpLearning.Core.CloudBookLists.BookListCells
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities;

    /// <summary>
    /// 书单格子（1个格子，最多可以放一本书）
    /// </summary>
    [Table(AbpLearningConsts.TablePreFixName.CloudBookList + nameof(BookListCell), Schema = AbpLearningConsts.TableSchemaName.CloudBookList)]
    public class BookListCell : Entity<long>, ISoftDelete, IMayHaveTenant
    {
        public BookListCell(byte sort, long bookId, long bookListId)
        {
            Sort = sort;
            BookId = bookId;
            BookListId = bookListId;
        }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public byte Sort { get; private set; }

        /// <summary>
        /// 书籍
        /// </summary>
        [Required]
        public long BookId { get; private set; }

        [Required]
        public long BookListId { get; private set; }

        public bool IsDeleted { get; set; }

        public int? TenantId { get; set; }
    }
}
