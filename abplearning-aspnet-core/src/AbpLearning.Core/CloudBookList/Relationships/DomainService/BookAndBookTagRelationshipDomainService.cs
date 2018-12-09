namespace AbpLearning.Core.CloudBookList.Relationships.DomainService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Repositories;
    using Abp.Domain.Services;
    using Microsoft.EntityFrameworkCore;

    public class BookAndBookTagRelationshipDomainService : DomainService, IBookAndBookTagRelationshipDomainService
    {
        private readonly IRepository<BookAndBookTagRelationship, long> _repository;

        public BookAndBookTagRelationshipDomainService(IRepository<BookAndBookTagRelationship, long> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BookAndBookTagRelationship>> GetByBookIdAsync(long bookId)
        {
            return await _repository.GetAll()
                .AsNoTracking()
                .Where(o => o.BookId == bookId)
                .Include(m => m.BookTag)
                .Include(m => m.Book)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookAndBookTagRelationship>> GetByBookTagIdAsync(long bookTagId)
        {
            return await _repository.GetAll()
                .AsNoTracking()
                .Where(o => o.BookTagId == bookTagId)
                .ToListAsync();
        }

        public async Task AddRelationshipAsync(long bookId, IEnumerable<long> bookTagIds)
        {
            // 原有关联
            var bookTagIdsForBook = await _repository.GetAll().AsNoTracking().Where(m => m.BookId == bookId)
                .Select(m => m.BookTagId).ToListAsync();

            // 已有关联缓存
            var insertedCache = new List<long>();
            var ids = bookTagIds.Distinct().OrderBy(m => m).Where(m => bookTagIdsForBook?.Contains(m) == false);

            foreach (var bookTagId in ids)
            {
                if (insertedCache.Exists(m => m == bookTagId))
                {
                    continue;
                }

                await _repository.InsertAsync(new BookAndBookTagRelationship(bookId, bookTagId));

                insertedCache.Add(bookTagId);
            }
        }

        public async Task DeleteRelationshipAsync(long bookId, IEnumerable<long> bookTagIds)
        {
            // 原有关联
            var bookTagIdsForBook = await _repository.GetAll().AsNoTracking().Where(m => m.BookId == bookId)
                .Select(m => m.BookTagId).ToListAsync();

            var ids = bookTagIds.Distinct().OrderBy(m => m).Where(m => bookTagIdsForBook?.Contains(m) == true);

            await _repository.DeleteAsync(m => m.BookId == bookId && ids.Contains(m.BookId));
        }

        public async Task BatchDeleteByBookIdAsync(IEnumerable<long> bookIds)
        {
            await _repository.DeleteAsync(o => bookIds.Contains(o.BookId));
        }

        public async Task DeleteByBookIdAsync(long bookId)
        {
            await _repository.DeleteAsync(o => o.BookId == bookId);
        }

        public async Task DeleteByBookTagIdAsync(long bookTagId)
        {
            await _repository.DeleteAsync(o => o.BookTagId == bookTagId);
        }

        public async Task BatchDeleteByBookTagIdAsync(IEnumerable<long> bookTagIds)
        {
            await _repository.DeleteAsync(o => bookTagIds.Contains(o.BookTagId));
        }
    }
}
