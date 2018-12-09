namespace AbpLearning.Core.CloudBookList.Relationships.DomainService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Repositories;
    using Abp.Domain.Services;
    using Microsoft.EntityFrameworkCore;

    public class BookListAndBookRelationshipDomainService : DomainService, IBookListAndBookRelationshipDomainService
    {
        private readonly IRepository<BookListAndBookRelationship, long> _repository;

        public BookListAndBookRelationshipDomainService(IRepository<BookListAndBookRelationship, long> repository)
        {
            _repository = repository;
        }

        public async Task AddRelationshipAsync(long bookListId, IEnumerable<long> bookIds)
        {
            // 原有关联
            var bookIdsForBookList = await _repository.GetAll().AsNoTracking().Where(m => m.BookListId == bookListId)
                .Select(m => m.BookId).ToListAsync();

            // 已有关联缓存
            var insertedCache = new List<long>();
            var ids = bookIds.Distinct().OrderBy(m => m).Where(m => bookIdsForBookList?.Contains(m) == false);

            foreach (var bookId in ids)
            {
                if (insertedCache.Exists(m => m == bookId))
                {
                    continue;
                }

                await _repository.InsertAsync(new BookListAndBookRelationship(bookListId, bookId));

                insertedCache.Add(bookId);
            }
        }

        public async Task DeleteRelationshipAsync(long bookListId, IEnumerable<long> bookIds)
        {
            // 原有关联
            var bookIdsForBookList = await _repository.GetAll().AsNoTracking().Where(m => m.BookListId == bookListId)
                .Select(m => m.BookId).ToListAsync();

            var ids = bookIds.Distinct().OrderBy(m => m).Where(m => bookIdsForBookList?.Contains(m) == true);

            await  _repository.DeleteAsync(m => m.BookListId == bookListId && ids.Contains(m.BookId));
        }

        public async Task BatchDeleteByBookIdAsync(IEnumerable<long> bookIds)
        {
            await _repository.DeleteAsync(m => bookIds.Contains(m.BookId));
        }

        public async Task DeleteByBookIdAsync(long bookId)
        {
            await _repository.DeleteAsync(m => m.BookId == bookId);
        }

        public async Task DeleteByBookListIdAsync(long bookListId)
        {
            await _repository.DeleteAsync(m => m.BookListId == bookListId);
        }

        public async Task BatchDeleteByBookListIdAsync(IEnumerable<long> bookListIds)
        {
            await _repository.DeleteAsync(m => bookListIds.Contains(m.BookListId));
        }

        public async Task<IEnumerable<BookListAndBookRelationship>> GetByBookIdAsync(long bookId)
        {
            return await _repository.GetAll().AsNoTracking()
                .Where(m => m.BookId == bookId)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookListAndBookRelationship>> GetByBookListIdAsync(long bookListId)
        {
            return await _repository.GetAll().AsNoTracking()
                .Where(m => m.BookListId == bookListId)
                .ToListAsync();
        }
    }
}
