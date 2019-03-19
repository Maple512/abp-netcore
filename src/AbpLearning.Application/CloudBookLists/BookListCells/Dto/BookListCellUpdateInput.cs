namespace AbpLearning.Application.CloudBookLists.BookCells.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;

    public class BookListCellUpdateInput : NullableIdDto<long>
    {
        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public byte Sort { get; set; }

        /// <summary>
        /// 书籍
        /// </summary>
        [Required]
        public long BookId { get; set; }

        [Required]
        public long BookListId { get; set; }
    }
}
