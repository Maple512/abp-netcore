namespace AbpLearning.Application.CloudBookLists.Books.Model
{
    using AbpLearning.Core.CloudBookLists.Books;
    using AutoMapper;

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
            configuration.CreateMap<BookEditModel, Book>()
                .ForMember(o => o.Tags, options => options.Ignore());

            configuration.CreateMap<Book, BookViewModel>();

            configuration.CreateMap<Book, BookPagedModel>()
                .ForMember(o => o.LastModificationTime,
                    option => option.MapFrom(m => m.LastModificationTime ?? m.CreationTime));
        }
    }
}
