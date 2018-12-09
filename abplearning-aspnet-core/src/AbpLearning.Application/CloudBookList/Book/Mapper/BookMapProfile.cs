namespace AbpLearning.Application.CloudBookList.Book.Mapper
{
    using AutoMapper;
    using Model;

    public class BookMapProfile : Profile
    {
        public BookMapProfile()
        {
            CreateMap<BookEditModel, Core.CloudBookList.Books.Book>();

            CreateMap<Core.CloudBookList.Books.Book, BookViewModel>();

            CreateMap<Core.CloudBookList.Books.Book, BookPagedModel>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime))
                .ForMember(o => o.ExsitedBookListCount, option => option.Ignore())
                .ForMember(o => o.TenancyDisplayName, option => option.Ignore())
                .ForMember(o => o.BookTags, option => option.Ignore());
        }
    }
}
