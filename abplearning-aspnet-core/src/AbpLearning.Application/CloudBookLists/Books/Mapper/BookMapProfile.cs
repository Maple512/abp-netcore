namespace AbpLearning.Application.CloudBookLists.Books.Mapper
{
    using System.Collections.Generic;
    using Abp.AutoMapper;
    using AutoMapper;
    using BookTags.Model;
    using Core.CloudBookLists.Books;
    using Model;

    public class BookMapProfile : Profile
    {
        public BookMapProfile()
        {
            CreateMap<BookEditModel, Book>()
                .ForMember(o => o.Tags, options => options.Ignore());

            CreateMap<Book, BookEditModel>()
                .ForMember(o => o.Lists, options => options.Ignore())
                .ForMember(o => o.Tags, options => options.MapFrom(m => m.Tags.MapTo<List<BookTagEditModel>>()));

            CreateMap<Book, BookViewModel>();

            CreateMap<Book, BookPagedModel>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime))
                .ForMember(o => o.Tags, options => options.MapFrom(m => m.Tags.MapTo<List<BookTagViewModel>>()))
                .ForMember(o => o.TenancyDisplayName, option => option.Ignore());
        }
    }
}
