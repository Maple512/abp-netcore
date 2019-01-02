namespace AbpLearning.Application.CloudBookLists.Books.Model
{
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using BookTags.Model;
    using Core.CloudBookLists.Books;

    /// <summary>
    /// <see cref="Book"/> 分页模型
    /// </summary>
    [AutoMapFrom(typeof(Book))]
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
