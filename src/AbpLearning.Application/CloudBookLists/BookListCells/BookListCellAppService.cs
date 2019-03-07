namespace AbpLearning.Application.CloudBookLists.BookLists
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Application.CloudBookLists.BookCells.Model;
    using Core.CloudBookLists.BookListCells;
    using Core.CloudBookLists.BookListCells.DomainService;

    public class BookListCellAppService : ApplicationService, IBookListCellAppService
    {
        private readonly IBookListCellDomainService _bookListCell;

        public BookListCellAppService(IBookListCellDomainService bookListCell)
        {
            _bookListCell = bookListCell;
        }

        /// <summary>
        /// 删除格子
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task BatchDeleteAsync(IEnumerable<long> model)
        {
            await _bookListCell.BatchDeleteAsync(model);
        }

        /// <summary>
        /// 增加格子
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        public async Task BatchInsertAsync(IEnumerable<BookListCellEditModel> cells)
        {
            var entities = ObjectMapper.Map<List<BookListCell>>(cells);
            await _bookListCell.BatchCreateAsync(entities);
        }
    }
}
