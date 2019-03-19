namespace AbpLearning.Application.CloudBookLists.Books.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using AbpLearning.Application.Base;

    public class BookCreateInput : INullIdEntityDto
    {
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
        public List<string> Tags { get; set; }
    }
}
