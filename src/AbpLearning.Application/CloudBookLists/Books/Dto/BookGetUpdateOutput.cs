namespace AbpLearning.Application.CloudBookLists.Books.Dto
{
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;

    public class BookGetUpdateOutput : EntityDto<long>
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
        /// 标签
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
