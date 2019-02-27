namespace AbpLearning.Application.CloudBookLists.Books.Model
{
    using System;
    using Abp.AutoMapper;
    using Core.CloudBookLists.Books;

    /// <summary>
    /// <see cref="Book"/> 分页模型
    /// </summary>
    [AutoMapFrom(typeof(Book))]
    public class BookPagedModel
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
        /// 简介
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
    }
}
