namespace AbpLearning.Application.CloudBookLists.BookLists.Mapper
{
    using AutoMapper;
    using Core.CloudBookLists.BookLists;
    using Model;

    public class BookListMapProfile : Profile
    {
        public BookListMapProfile()
        {
            CreateMap<BookListEditModel, BookList>();

            CreateMap<BookList, BookListViewModel>();

            CreateMap<BookList, BookListPagedModel>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime))
                .ForMember(o => o.ExsitedBookCount, option => option.MapFrom(m => m.Cells.Count));
        }
    }
}
