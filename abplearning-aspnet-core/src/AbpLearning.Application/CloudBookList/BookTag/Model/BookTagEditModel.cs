namespace AbpLearning.Application.CloudBookList.BookTag.Model
{
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using Core.CloudBookList.BookTags;

    [AutoMapTo(typeof(BookTag))]
    public class BookTagEditModel
    {
        public long? Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
