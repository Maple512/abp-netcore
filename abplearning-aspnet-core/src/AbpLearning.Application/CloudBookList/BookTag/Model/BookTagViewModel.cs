namespace AbpLearning.Application.CloudBookList.BookTag.Model
{
    using Abp.AutoMapper;

    /// <summary>
    /// 
    /// </summary>
    [AutoMapFrom(typeof(Core.CloudBookList.BookTags.BookTag))]
    public class BookTagViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Color { get; set; }
    }
}
