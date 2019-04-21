namespace AbpLearning.Application.Languages.Dto
{
    using System;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Entities.Auditing;

    public class LanguagePagedDto : EntityDto,IHasModificationTime
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Icon { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
