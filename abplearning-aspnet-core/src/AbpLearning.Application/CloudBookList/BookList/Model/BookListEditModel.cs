namespace AbpLearning.Application.CloudBookList.BookList.Model
{
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;

    [AutoMapTo(typeof(Core.CloudBookList.BookLists.BookList))]
    public class BookListEditModel
    {
        public long? Id { get; set; }

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
