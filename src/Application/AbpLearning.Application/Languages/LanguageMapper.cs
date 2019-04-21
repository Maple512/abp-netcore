namespace AbpLearning.Application.Languages
{
    using Abp.Localization;
    using AbpLearning.Application.Languages.Dto;
    using AutoMapper;

    public class LanguageMapper : Profile
    {
        public LanguageMapper()
        {
            CreateMap<ApplicationLanguage, LanguagePagedDto>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime));
        }
    }
}
