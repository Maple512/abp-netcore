namespace AbpLearning.Application.CloudBookLists.BookCells.Model
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using AbpLearning.Core.CloudBookLists.BookListCells;

    [AutoMapTo(typeof(BookListCell))]
    public class BookListCellEditModel : NullableIdDto<long>
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
