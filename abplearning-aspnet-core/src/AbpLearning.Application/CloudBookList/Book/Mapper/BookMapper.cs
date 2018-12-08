namespace AbpLearning.Application.CloudBookList.Book.Mapper
{
    using AutoMapper;
    using Model;

    internal static class BookMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Core.CloudBookList.Books.Book, BookPagedModel>()
                .ForMember(o => o.TenancyDisplayName, m => m.Ignore());
        }
    }
}
