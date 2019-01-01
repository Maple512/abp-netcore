namespace AbpLearning.Application.CloudBookList.BookTag.Mapper
{
    using AutoMapper;
    using Model;

    public class BookTagMapProfile : Profile
    {
        public BookTagMapProfile()
        {
            CreateMap<BookTagEditModel, Core.CloudBookList.BookTags.BookTag>();
            CreateMap<Core.CloudBookList.BookTags.BookTag, BookTagEditModel>();

            CreateMap<Core.CloudBookList.BookTags.BookTag, BookTagViewModel>();
        }
    }
}
