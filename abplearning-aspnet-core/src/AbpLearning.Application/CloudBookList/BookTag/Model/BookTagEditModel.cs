namespace AbpLearning.Application.CloudBookList.BookTag.Model
{
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using Core.CloudBookList.BookTags;

    [AutoMapTo(typeof(BookTag))]
    public class BookTagEditModel
    {
        public long? Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string Name { get; set; }
    }
}
