namespace AbpLearning.Application.CloudBookLists.Books.Model
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Core.CloudBookLists.Books;

    [AutoMapFrom(typeof(Book))]
    public class BookGetViewOutput: NullableIdDto<long>
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
        /// 简介
        /// </summary>
        public string Intro { get; set; }
    }
}
