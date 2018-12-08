namespace AbpLearning.Application.CloudBookList.BookTag.Model
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Abp.Domain.Entities.Auditing;

    [AutoMapFrom(typeof(Core.CloudBookList.BookTags.BookTag))]
    public class BookTagPagedModel : EntityDto<long>, IHasModificationTime
    {
        public string Name { get; set; }

        public string TenancyDisplayName { get; set; }

        /// <summary>
        /// 包含该书签的书的数量
        /// </summary>
        public int IncludedBooks { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
