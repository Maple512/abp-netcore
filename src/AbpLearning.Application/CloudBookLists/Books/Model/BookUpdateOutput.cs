namespace AbpLearning.Application.CloudBookLists.Books.Model
{
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Core.CloudBookLists.Books;

    /// <summary>
    /// <see cref="Book"/> 更新模型
    /// </summary>
    [AutoMapTo(typeof(Book))]
    public class BookUpdateOutput : EntityDto<long>
    {
        /// <summary>
        /// 封面URL
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
        /// 简介
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        /// 购买、详情
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 书籍能拥有的最大书签
        /// </summary>
        public byte TagsMaxLength => Book.TagsMaxLength;

        /// <summary>
        /// 标签
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
