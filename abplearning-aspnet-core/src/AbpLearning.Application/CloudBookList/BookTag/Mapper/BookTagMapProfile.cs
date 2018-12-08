namespace AbpLearning.Application.CloudBookList.BookTag.Mapper
{
    using System.Linq;
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
                .ForMember(o => o.IncludedBooks, option => option.MapFrom(m => m.BookAndBookTagRelationships.Count()));
        }
    }
}
