namespace AbpLearning.Application.CloudBookList.BookTag.Model
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Core.CloudBookList.BookTags.BookTag))]
    public class BookTagPagedModel : AuditedEntityDto<long>
    {
        public string Name { get; set; }

        public string TenancyDisplayName { get; set; }

        /// <summary>
        /// 被多少本书籍引用
        /// </summary>
        public int ExistedBookCount { get; set; }
    }
}
