namespace AbpLearning.Core.CloudBookList.BookLiseCells.DomainService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Repositories;
    using Base;

    public class BookListCellDomainService : DomainServiceBase<BookListCell, long>, IBookListCellDomainService
    {
        public BookListCellDomainService(IRepository<BookListCell, long> bookRepository) : base(bookRepository)
        {
        }

        public async Task<BookListCell> GetForBookAsync(long bookId)
        {
            return await _repository.FirstOrDefaultAsync(m => m.BookId == bookId);
        }

        public async Task<IEnumerable<BookListCell>> GetForBookAsnyc(IEnumerable<long> bookIds)
        {
            return await _repository.GetAllListAsync(m => bookIds.Contains(m.BookId));
        }

        public async Task DeleteForBookAsync(long bookId)
        {
            var entity = await GetForBookAsync(bookId);

            await DeleteAsync(entity.Id);
        }

        public async Task BatchDeleteForBookAsync(IEnumerable<long> bookIds)
        {
            var entities = await GetForBookAsnyc(bookIds);

            await BatchDeleteAsync(entities.Select(m => m.Id));
        }
    }
}
