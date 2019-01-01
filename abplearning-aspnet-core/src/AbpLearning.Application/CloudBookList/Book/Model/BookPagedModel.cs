namespace AbpLearning.Application.CloudBookList.Book.Model
{
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using BookTag.Model;

    /// <summary>
    /// <see cref="Core.CloudBookList.Books.Book"/> 分页模型
    /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        public string TenancyDisplayName { get; set; }

        /// <summary>
        /// 书签
        /// </summary>
        public List<BookTagViewModel> Tags { get; set; }
    }
}
