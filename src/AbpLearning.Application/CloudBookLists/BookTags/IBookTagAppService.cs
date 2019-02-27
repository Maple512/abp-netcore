namespace AbpLearning.Application.CloudBookLists.BookTags
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Model;

    public interface IBookTagAppService : IApplicationService
    {
        Task<List<BookTagEditModel>> GetEditForBookAsync(EntityDto<long> bookModel);

        Task<List<BookTagViewModel>> GetViewForBookAsync(EntityDto<long> bookModel);

        Task CreateForBookAsync(BookTagEditModel model);

        Task DeleteForBookAsync(EntityDto<long> bookModel);
    }
}
