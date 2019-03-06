namespace AbpLearning.Application.Roles.Mapper
{
    using Abp.Authorization;
    using Abp.Authorization.Roles;
    using AbpLearning.Core.Authorization.Roles;
    using AutoMapper;
    using Model;

    public class RoleMapProfile : Profile
    {
        public RoleMapProfile()
        {
            // Role and permission
            CreateMap<Permission, string>().ConvertUsing(r => r.Name);
            CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

            CreateMap<Role, RolePagedModel>()
                .ForMember(x => x.LastModificationTime,
                    opt => opt.MapFrom(o => o.LastModificationTime ?? o.CreationTime));

            CreateMap<RoleEditModel, Role>();
            CreateMap<Role, RoleEditModel>();

        }
    }
}
