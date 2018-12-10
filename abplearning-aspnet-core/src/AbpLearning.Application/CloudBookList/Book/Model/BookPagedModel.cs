namespace AbpLearning.Application.CloudBookList.Book.Model
{
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using BookTag.Model;

    [AutoMapFrom(typeof(Core.CloudBookList.Books.Book))]
    public class BookPagedModel : AuditedEntityDto<long>
    {
        /// <summary>
        /// 封面图片URL
        /// </summary>
        public string CoverImgUrl { get; set; }

        /// <summary>
        /// 书名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }

        public string TenancyDisplayName { get; set; }

        /// <summary>
        /// 书签
        /// </summary>
        public List<BookTagViewModel> BookTags { get; set; }

        /// <summary>
        /// 存在于多少个书单中
        /// </summary>
        public int ExsitedBookListCount { get; set; }
    }
}
