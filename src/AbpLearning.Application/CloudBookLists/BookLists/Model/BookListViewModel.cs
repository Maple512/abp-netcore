namespace AbpLearning.Application.CloudBookLists.BookLists.Model
{
    using Abp.AutoMapper;
    using Core.CloudBookLists.BookLists;

    [AutoMapFrom(typeof(BookList))]
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
