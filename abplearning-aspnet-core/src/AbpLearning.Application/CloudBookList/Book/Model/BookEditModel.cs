using System.ComponentModel;

namespace AbpLearning.Application.CloudBookList.Book.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using AbpLearning.Application.CloudBookList.BookList.Model;
    using AbpLearning.Application.CloudBookList.BookTag.Model;

    /// <summary>
    /// <see cref="Core.CloudBookList.Books.Book"/> 更新模型
    /// </summary>
    [AutoMapTo(typeof(Core.CloudBookList.Books.Book))]
    public class BookEditModel
    {
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
