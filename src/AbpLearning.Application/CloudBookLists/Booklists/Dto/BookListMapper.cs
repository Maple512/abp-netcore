namespace AbpLearning.Application.CloudBookLists.Booklists.Dto
{
    using AbpLearning.Application.CloudBookLists.BookLists.Dto;
    using AbpLearning.Core.CloudBookLists.BookLists;
    using AutoMapper;

    public class BookListMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<BookList, BookListGetPagedOutput>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime));
        }
    }
}
