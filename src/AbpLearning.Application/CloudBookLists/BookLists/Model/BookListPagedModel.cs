namespace AbpLearning.Application.CloudBookLists.BookLists.Model
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Core.CloudBookLists.BookLists;

    [AutoMapFrom(typeof(BookList))]
    public class BookListPagedModel : AuditedEntityDto<long>
    {
        /// <summary>
        /// 书单名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        /// 书单中存在多少本书籍
        /// </summary>
        public int ExsitedBookCount { get; set; }
    }
}
