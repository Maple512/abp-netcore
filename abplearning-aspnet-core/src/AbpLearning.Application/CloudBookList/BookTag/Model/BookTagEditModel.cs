namespace AbpLearning.Application.CloudBookList.BookTag.Model
{
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using Core.CloudBookList.BookTags;

    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(BookTag))]
    public class BookTagEditModel
    {
        /// <summary>
        /// 
        /// </summary>
        public long? Id { get; set; }

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
    }
}
