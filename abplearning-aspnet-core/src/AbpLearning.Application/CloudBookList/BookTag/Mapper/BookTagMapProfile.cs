namespace AbpLearning.CloudBookList.BookTag.Mapper
{
    using Application.CloudBookList.BookTag.Model;
    using AutoMapper;
    using Core.CloudBookList.BookTags;

    public class BookTagMapProfile : Profile
    {
        public BookTagMapProfile()
        {
            CreateMap<BookTagEditModel, BookTag>();
        }
    }
}
