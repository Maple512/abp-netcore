namespace AbpLearning.Core.Files.DomainService
{
    using Abp.Domain.Repositories;
    using AbpLearning.Core.Base;

    public class FileTypeDomainService : DomainServiceBase<FileType, int>, IFileTypeDomainService
    {
        public FileTypeDomainService(IRepository<FileType, int> repository) : base(repository)
        {
        }
    }
}
