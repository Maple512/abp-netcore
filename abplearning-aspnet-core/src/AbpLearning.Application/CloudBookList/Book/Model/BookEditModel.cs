namespace AbpLearning.Application.CloudBookList.Book.Model
{
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;

    [AutoMapTo(typeof(Core.CloudBookList.Books.Book))]
    public class BookEditModel
    {
        public long? Id { get; set; }

        [MaxLength(128)]
        [DataType(DataType.Url)]
        public string CoverImgUrl { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [MaxLength(32)]
        public string Author { get; set; }

        [MaxLength(512)]
        public string Intro { get; set; }

        [MaxLength(128)]
        [DataType(DataType.Url)]
        public string Url { get; set; }
    }
}
