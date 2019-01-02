namespace AbpLearning.Application.CloudBookLists.BookTags.Model
{
    using Abp.AutoMapper;
    using Core.CloudBookLists.BookTags;

    /// <summary>
    /// 
    /// </summary>
    [AutoMapFrom(typeof(BookTag))]
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
