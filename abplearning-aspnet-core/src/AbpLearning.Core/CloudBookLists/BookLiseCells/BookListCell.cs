namespace AbpLearning.Core.CloudBookLists.BookLiseCells
{
    using Abp.Domain.Entities;
    using Books;

    /// <summary>
    /// 书单格子
    /// </summary>
    public class BookListCell : Entity<long>, IMayHaveTenant, ISoftDelete
    {
        /// <summary>
        /// 排序
        /// </summary>
        public byte Sort { get; set; }

        public long BookId { get; set; }

        public long BookListId { get; set; }

        public int? TenantId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
