namespace AbpLearning.Application.CloudBookLists.Books.Dto
{
    using AbpLearning.Core.CloudBookLists.Books;
    using AutoMapper;
    using Abp.Json;

    /// <summary>
    /// Book 映射配置
    /// </summary>
    public class BookMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<BookGetUpdateOutput, Book>()
                .ForMember(o => o.Tags, options => options.Ignore());

            configuration.CreateMap<Book, BookGetViewOutput>();

            configuration.CreateMap<Book, BookGetPagedOutput>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime));

            configuration.CreateMap<BookCreateInput, Book>()
                .ForMember(o => o.TagJson,
                    opt => opt.MapFrom(m => m.Tags.ToJsonString(false, false)));
        }
    }
}
