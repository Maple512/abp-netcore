namespace AbpLearning.Application.CloudBookLists.BookLists.Model
{
    using System.ComponentModel.DataAnnotations;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using AbpLearning.Core.CloudBookLists.BookLists;

    [AutoMapFrom(typeof(BookList))]
    public class BookListGetUpdateOutput : EntityDto<long>
    {
        /// <summary>
        /// 书单名
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(128)]
        public string Intro { get; set; }
    }
}
