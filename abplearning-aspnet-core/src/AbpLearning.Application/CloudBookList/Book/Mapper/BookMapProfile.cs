namespace AbpLearning.Application.CloudBookList.Book.Mapper
{
    using AutoMapper;
    using Model;

    public class BookMapProfile : Profile
    {
        public BookMapProfile()
        {
            CreateMap<BookEditModel, Core.CloudBookList.Books.Book>()
                .ForMember(o => o.Tags, options => options.Ignore());

            CreateMap<Core.CloudBookList.Books.Book, BookEditModel>()
                .ForMember(o => o.Lists, options => options.Ignore());

            CreateMap<Core.CloudBookList.Books.Book, BookViewModel>();

            CreateMap<Core.CloudBookList.Books.Book, BookPagedModel>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime))
                .ForMember(o => o.TenancyDisplayName, option => option.Ignore())
                .ForMember(o => o.Tags, option => option.Ignore());
        }
    }
}
