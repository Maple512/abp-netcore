namespace AbpLearning.Application.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Abp.Extensions;
    using Abp.Json;
    using Abp.Linq.Extensions;
    using AbpLearning.Application.Files.Model;
    using AbpLearning.Core.Files;
    using AbpLearning.Core.Files.DomainService;
    using Microsoft.EntityFrameworkCore;

    public class FilesAppService : IFilesAppService
    {
        private readonly IFileTypeDomainService _fileType;
        private readonly IUploadFileDomainService _uploadFile;

        public FilesAppService(IFileTypeDomainService fileType, IUploadFileDomainService uploadFile)
        {
            _fileType = fileType;
            _uploadFile = uploadFile;
        }


        #region FileType

        public async Task BetchDeleteForFileTypeAsync(List<EntityDto> listEntity)
        {
            var ids = listEntity.Select(m => m.Id);
            await _fileType.BatchDeleteAsync(ids);
        }

        public async Task DeleteForFileTypeAsync(EntityDto entity)
        {
            await _fileType.DeleteAsync(entity.Id);
        }

        public async Task<PagedResultDto<FileTypePagedModel>> GetPagedForFileTypeAsync(FileTypePagedFilteringModel filter)
        {
            var query = _fileType.GetAll()
                .WhereIf(!filter.Name.IsNullOrWhiteSpace(), m => m.Name.Contains(filter.Name));

            var count = await query.CountAsync();

            var entityList = query.OrderBy(filter.Sorting).PageBy(filter);

            var pagedModels = entityList.MapTo<List<FileTypePagedModel>>();

            return new PagedResultDto<FileTypePagedModel>(count, pagedModels);
        }

        public async Task CreateOrUpdateAsync(FileTypeEditModel editModel)
        {
            var entity = editModel.MapTo<FileType>();

            entity.ExtensionJSON = editModel.Extensions.ToJsonString();

            await _fileType.CreateOrUpdateAsync(entity);
        }

        /// <summary>
        /// 获取所有文件类型
        /// </summary>
        /// <returns></returns>
        public async Task<List<FileTypeViewModel>> GetAll()
        {
            var list = await _fileType.GetAll().ToListAsync();

            return list.MapTo<List<FileTypeViewModel>>();
        }

        #endregion

        #region UploadFile

        public async Task BetchDeleteForUploadFileAsync(List<EntityDto<Guid>> listEntity)
        {
            var ids = listEntity.Select(m => m.Id);
            await _uploadFile.BatchDeleteAsync(ids);
        }

        public async Task DeleteForUploadFileAsync(EntityDto<Guid> entity)
        {
            await _uploadFile.DeleteAsync(entity.Id);
        }

        public async Task<PagedResultDto<UploadFilePagedModel>> GetPagedForUploadFileAsync(UploadFilePagedFilteringModel filter)
        {
            var query = _uploadFile.GetAll()
                .WhereIf(!filter.Name.IsNullOrWhiteSpace(), m => m.Name.Contains(filter.Name))
                .WhereIf(filter.FileType.HasValue, m => m.FileType == (filter.FileType == -1 ? null : filter.FileType))
                .WhereIf(filter.StartTime.HasValue, m => m.CreationTime >= filter.StartTime)
                .WhereIf(filter.EndTime.HasValue, m => m.CreationTime <= filter.EndTime);

            var count = await query.CountAsync();

            var entityList = query.OrderBy(filter.Sorting).PageBy(filter).Include(m => m.TypeName);

            var pagedModels = entityList.MapTo<List<UploadFilePagedModel>>();

            return new PagedResultDto<UploadFilePagedModel>(count, pagedModels);
        }

        public async Task InsertForUploadFileAsync(UploadFileEditModel editModel)
        {
            var entity = editModel.MapTo<UploadFile>();

            await _uploadFile.InsertAsync(entity);
        }

        #endregion
    }
}
