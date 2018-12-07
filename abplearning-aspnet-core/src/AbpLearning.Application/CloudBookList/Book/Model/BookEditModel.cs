namespace AbpLearning.Application.CloudBookList.Book.Model
{
    using System.ComponentModel.DataAnnotations;

    public class BookEditModel
    {
        public long? Id { get; set; }

        public string ImgUrl { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        public string Intro { get; set; }

        public string Url { get; set; }
    }
}
