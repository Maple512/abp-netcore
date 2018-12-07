namespace AbpLearning.Core.CloudBookList.Relationships.DomainService
{
    using System;
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
                .ToListAsync();
        }

        public async Task<IEnumerable<BookAndBookTagRelationship>> GetByBookTagIdAsync(long bookTagId)
        {
            return await _repository.GetAll()
                .AsNoTracking()
                .Where(o => o.BookTagId == bookTagId)
                .ToListAsync();
        }

        public async Task CreateRelationshipAsync(long bookId, IEnumerable<long> bookTagIds)
        {
            // 删除原有的关联
            await _repository.DeleteAsync(o => o.BookId == bookId);
            await CurrentUnitOfWork.SaveChangesAsync();


            // 创建关联
            var insertdBookTagIds = new List<long>();
            foreach (var bookTagId in bookTagIds)
            {
                // 已经插入过了
                if (insertdBookTagIds.Exists(o => o == bookTagId))
                {
                    continue;
                }

                await _repository.InsertAsync(new BookAndBookTagRelationship()
                {
                    BookId = bookId,
                    BookTagId = bookTagId,
                });
                insertdBookTagIds.Add(bookTagId);
            }
        }

        public async Task DeleteByBookIdAsync(long bookId)
        {
            await _repository.DeleteAsync(o => o.BookId == bookId);
        }

        public async Task DeleteByBookIdAsync(IEnumerable<long> bookIds)
        {
            await _repository.DeleteAsync(o => bookIds.Contains(o.BookId));
        }

        public async Task DeleteByBookTagIdAsync(long bookTagId)
        {
            await _repository.DeleteAsync(o => o.BookTagId == bookTagId);
        }

        public async Task DeleteByBookTagIdAsync(IEnumerable<long> bookTagIds)
        {
            await _repository.DeleteAsync(o => bookTagIds.Contains(o.BookTagId));
        }
    }
}
