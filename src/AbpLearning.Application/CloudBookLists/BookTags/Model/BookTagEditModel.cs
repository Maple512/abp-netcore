namespace AbpLearning.Application.CloudBookLists.BookTags.Model
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Core.CloudBookLists.BookTags;

    [AutoMap(typeof(BookTag))]
    public class BookTagEditModel : NullableIdDto<long>
    {
        /// <summary>
        /// 标签名
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

        /// <summary>
        /// 所属书籍
        /// </summary>
        public long? BookId { get; set; }
    }
}
