namespace AbpLearning.Application.CloudBookLists.Books.Model
{
    using AbpLearning.Core.CloudBookLists.Books;
    using AutoMapper;
    using Abp.Json;

    /// <summary>
    /// Book 映射配置
    /// </summary>
    public class BookMapper
    {
        /// <summary>
        /// Book 创建映射
        /// </summary>
        /// <param name="configuration"></param>
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<BookUpdateOutput, Book>()
                .ForMember(o => o.Tags, options => options.Ignore());

            configuration.CreateMap<Book, BookViewOutput>();

            configuration.CreateMap<Book, BookPagedOutput>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime));

            configuration.CreateMap<BookCreateInput, Book>()
                .ForMember(o => o.TagJson,
                    opt => opt.MapFrom(m => m.Tags.ToJsonString(false, false)));
        }
    }
}
