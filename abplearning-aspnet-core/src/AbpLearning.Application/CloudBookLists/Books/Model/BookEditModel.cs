namespace AbpLearning.Application.CloudBookLists.Books.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using AbpLearning.Application.CloudBookLists.BookLists.Model;
    using AbpLearning.Application.CloudBookLists.BookTags.Model;
    using Core.CloudBookLists.Books;

    /// <summary>
    /// <see cref="Book"/> 更新模型
    /// </summary>
    [AutoMapTo(typeof(Book))]
    public class BookEditModel
    {
        public const byte TagsMaxLength = Book.TagsMaxLength;

        /// <summary>
        /// null：查看
        /// !null：更新
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 封面URL
        /// </summary>
        [MaxLength(128)]
        [DataType(DataType.Url)]
        public string CoverImgUrl { get; set; }

        /// <summary>
        /// 书名
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Author { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(512)]
        public string Intro { get; set; }

        /// <summary>
        /// 购买、详情
        /// </summary>
        [MaxLength(128)]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public List<BookTagEditModel> Tags { get; set; }

        /// <summary>
        /// 书单
        /// </summary>
        public List<BookListViewModel> Lists { get; set; }
    }
}
