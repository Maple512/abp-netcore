﻿namespace AbpLearning.Web.Host.Controllers
{
    using Abp.AspNetCore.Mvc.Authorization;
    using AbpLearning.Application.Files;
    using AbpLearning.Core.Files.Folders;
    using AbpLearning.Web.Core.Controllers;

    [AbpMvcAuthorize]
    public class ProfileController : FileServiceControllerBase
    {
        public ProfileController(IFilesAppService filesService, IAppFolderConfig appFolderConfig) : base(filesService, appFolderConfig)
        {
        }
    }
}
