namespace AbpLearning.Application.CloudBookList.BookTag.Mapper
{
    using AutoMapper;
    using Model;

    public class BookTagMapProfile : Profile
    {
        public BookTagMapProfile()
        {
            CreateMap<BookTagEditModel, Core.CloudBookList.BookTags.BookTag>();

            CreateMap<Core.CloudBookList.BookTags.BookTag, BookTagViewModel>();

            CreateMap<Core.CloudBookList.BookTags.BookTag, BookTagPagedModel>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime))
                .ForMember(o => o.ExistedBookCount, option => option.Ignore())
                .ForMember(o => o.TenancyDisplayName, option => option.Ignore());
        }
    }
}
