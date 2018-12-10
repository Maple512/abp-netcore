namespace AbpLearning.Application.CloudBookList.BookTag.Model
{
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Core.CloudBookList.BookTags.BookTag))]
    public class BookTagViewModel
    {
        public string Name { get; set; }

        public string Color { get; set; }
    }
}
