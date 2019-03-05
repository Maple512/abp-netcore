namespace AbpLearning.Application.CloudBookLists.Books.Mapper
{
    using System.Collections.Generic;
    using Abp.AutoMapper;
    using AutoMapper;
    using Core.CloudBookLists.Books;
    using Model;

    public class BookMapProfile : Profile
    {
        public BookMapProfile()
        {
            CreateMap<BookEditModel, Book>()
                .ForMember(o => o.Tags, options => options.Ignore());

            CreateMap<Book, BookViewModel>();

            CreateMap<Book, BookPagedModel>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime));
        }
    }
}
