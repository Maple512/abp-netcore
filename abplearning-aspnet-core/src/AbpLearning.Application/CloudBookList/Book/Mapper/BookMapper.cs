namespace AbpLearning.Application.CloudBookList.Book.Mapper
{
    using AutoMapper;
    using Model;
    using AbpLearning.Core.CloudBookList.Book;

    internal static class BookMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Book, BookPagedModel>()
                .ForMember(o => o.TenancyDisplayName, m => m.Ignore());
        }
    }
}
