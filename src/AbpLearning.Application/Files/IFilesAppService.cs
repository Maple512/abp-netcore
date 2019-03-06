namespace AbpLearning.Application.Files
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using AbpLearning.Application.Files.Model;

    public interface IFilesAppService : IApplicationService
    {
        #region UploadFile

        /// <summary>
        /// 上传文件后新增记录
        /// </summary>
        /// <param name="editModel"></param>
        /// <returns></returns>
        Task InsertForUploadFileAsync(UploadFileEditModel editModel);

        /// <summary>
        /// 删除文件后删除记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteForUploadFileAsync(EntityDto<Guid> entity);

        /// <summary>
        /// 删除文件后删除记录
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        Task BetchDeleteForUploadFileAsync(List<EntityDto<Guid>> listEntity);

        /// <summary>
        /// 文件列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<PagedResultDto<UploadFilePagedModel>> GetPagedForUploadFileAsync(UploadFilePagedFilteringModel filter);

        #endregion

        #region FileType

        /// <summary>
        /// 新增文件类型
        /// </summary>
        /// <param name="editModel"></param>
        /// <returns></returns>
        Task CreateOrUpdateAsync(FileTypeEditModel editModel);

        /// <summary>
        /// 删除文件类型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteForFileTypeAsync(EntityDto entity);

        /// <summary>
        /// 批量删除文件类型
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        Task BetchDeleteForFileTypeAsync(List<EntityDto> listEntity);

        /// <summary>
        /// 文件类型列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<PagedResultDto<FileTypePagedModel>> GetPagedForFileTypeAsync(FileTypePagedFilteringModel filter);

        /// <summary>
        /// 所有文件类型
        /// </summary>
        /// <returns></returns>
        Task<List<FileTypeViewModel>> GetAll();

        #endregion
    }
}
