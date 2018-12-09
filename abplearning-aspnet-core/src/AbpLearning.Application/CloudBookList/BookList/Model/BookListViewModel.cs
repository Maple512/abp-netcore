namespace AbpLearning.Application.CloudBookList.BookList.Model
{
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Core.CloudBookList.Books.Book))]
    public class BookListViewModel
    {
        /// <summary>
        /// 书单名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }
    }
}
