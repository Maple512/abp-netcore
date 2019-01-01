namespace AbpLearning.Core.CloudBookList.BookLiseCells
{
    using Abp.Domain.Entities;
    using BookLists;
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

        public virtual Book Book { get; set; }

        public long BookListId { get; set; }

        public virtual BookList BookList { get; set; }

        public int? TenantId { get; set; }

        public bool IsDeleted
        {
            get => ((ISoftDelete)Book).IsDeleted || ((ISoftDelete)BookList).IsDeleted || IsDeleted;
            set { }
        }
    }
}
