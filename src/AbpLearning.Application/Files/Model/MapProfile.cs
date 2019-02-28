namespace AbpLearning.Application.Files.Model
{
    using AbpLearning.Core.Files;
    using AutoMapper;

    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UploadFile, UploadFilePagedModel>()
                .ForMember(m => m.Type, opt => opt.MapFrom(m => m.TypeName.Name));
        }
    }
}
