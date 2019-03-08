namespace AbpLearning.Application.Authorization.Roles.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Entities.Auditing;

    public class RoleGetPagedOutput : EntityDto, IHasModificationTime
    {
        public DateTime? LastModificationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
