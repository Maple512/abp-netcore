﻿namespace AbpLearning.Application.CloudBookList.BookList.Mapper
{
    using AutoMapper;
    using Model;

    public class BooKListMapProfile : Profile
    {
        public BooKListMapProfile()
        {
            CreateMap<BookListEditModel, Core.CloudBookList.BookLists.BookList>();

            CreateMap<Core.CloudBookList.Books.Book, BookListViewModel>();

            CreateMap<Core.CloudBookList.Books.Book, BookListPagedModel>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime))
                .ForMember(o => o.ExsitedBookCount, option => option.Ignore());
        }
    }
}