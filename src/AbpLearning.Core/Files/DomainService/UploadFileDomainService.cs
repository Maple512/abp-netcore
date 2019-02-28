namespace AbpLearning.Core.Files.DomainService
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Repositories;
    using AbpLearning.Core.Base;

    public class UploadFileDomainService : DomainServiceBase<UploadFile, Guid>, IUploadFileDomainService
    {
        private readonly IRepository<FileType> _fileType;
        public UploadFileDomainService(IRepository<UploadFile, Guid> repository, IRepository<FileType> fileType) : base(repository)
        {
            _fileType = fileType;
        }

        public override Task InsertAsync(UploadFile entity)
        {
            entity.FileType = entity.FileType ?? _fileType.GetAll().FirstOrDefault(m => m.ExtensionJSON.Contains(entity.Extension))?.Id;
            return base.InsertAsync(entity);
        }
    }
}
