namespace AbpLearning.Core.CloudBookLists.BookLiseCells.DomainService
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

        public async Task<List<BookListCell>> GetForBookAsync(long bookId)
        {
            return await _repository.GetAllListAsync(m => m.BookId == bookId);
        }

        public async Task<List<BookListCell>> GetForBookAsync(List<long> bookIds)
        {
            return await _repository.GetAllListAsync(m => bookIds.Contains(m.BookId));
        }

        public async Task BatchDeleteForBookAsync(long bookId)
        {
            var entities = await GetForBookAsync(bookId);

            if (entities.Count > 0)
            {
                await BatchDeleteAsync(entities.Select(m => m.Id));
            }
        }

        public async Task BatchDeleteForBookAsync(List<long> bookIds)
        {
            var entities = await GetForBookAsync(bookIds);

            if (entities.Count > 0)
            {
                await BatchDeleteAsync(entities.Select(m => m.Id));
            }
        }
    }
}
