namespace AbpLearning.Core.CloudBookList.Relationships.DomainService
{
    using System;
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

        public async Task CreateRelationshipAsync(long bookListId, IEnumerable<long> bookIds)
        {
            // 删除原有关联
            await _repository.DeleteAsync(m => m.BookListId == bookListId);
            await CurrentUnitOfWork.SaveChangesAsync();

            // 创建关联
            var insertedBookIds = new List<long>();

            foreach (var bookId in bookIds)
            {
                if (insertedBookIds.Exists(m => m == bookId))
                {
                    continue;
                }

                await _repository.InsertAsync(new BookListAndBookRelationship
                {
                    BookId = bookId,
                    BookListId = bookListId
                });

                insertedBookIds.Add(bookId);
            }
        }

        public async Task DeleteByBookIdv(long bookId)
        {
            await _repository.DeleteAsync(m => m.BookId == bookId);
        }

        public async Task DeleteByBookIdAsync(IEnumerable<long> bookIds)
        {
            await _repository.DeleteAsync(m => bookIds.Contains(m.BookId));
        }

        public async Task DeleteByBookListIdAsync(long bookListId)
        {
            await _repository.DeleteAsync(m => m.BookListId == bookListId);
        }

        public async Task DeleteByBookListIdAsync(IEnumerable<long> bookListIds)
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
