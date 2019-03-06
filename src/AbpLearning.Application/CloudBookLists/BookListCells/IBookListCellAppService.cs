namespace AbpLearning.Application.CloudBookLists.BookLists
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using AbpLearning.Application.CloudBookLists.BookCells.Model;

    public interface IBookListCellAppService : IApplicationService
    {
        /// <summary>
        /// 增加格子
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        Task BatchInsertAsync(IEnumerable<BookListCellEditModel> cells);

        /// <summary>
        /// 删除格子
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task BatchDeleteAsync(IEnumerable<long> model);

    }
}
