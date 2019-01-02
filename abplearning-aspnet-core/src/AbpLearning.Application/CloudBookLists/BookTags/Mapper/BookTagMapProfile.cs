namespace AbpLearning.Application.CloudBookLists.BookTags.Mapper
{
    using AbpLearning.Core.CloudBookLists.BookTags;
    using AutoMapper;
    using Model;

    public class BookTagMapProfile : Profile
    {
        public BookTagMapProfile()
        {
            CreateMap<BookTagEditModel, BookTag>();
            CreateMap<BookTag, BookTagEditModel>();

            CreateMap<BookTag, BookTagViewModel>();
        }
    }
}
