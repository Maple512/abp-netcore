namespace AbpLearning.Core.Base
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Entities;
    using Abp.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;

    public abstract class DomainServiceBase<T, TPrimaryKey> : IDomainServiceBase<T, TPrimaryKey>
        where T : Entity<TPrimaryKey>
    {
        private readonly IRepository<T, TPrimaryKey> _bookRepository;

        public DomainServiceBase(
            IRepository<T, TPrimaryKey> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task CreateOrUpdateAsync(T book)
        {
            await _bookRepository.InsertOrUpdateAsync(book);
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task BatchDeleteAsync(IEnumerable<TPrimaryKey> list)
        {
            await _bookRepository.DeleteAsync(m => list.Contains(m.Id));
        }

        public Task<T> GetAsync(TPrimaryKey id)
        {
            return _bookRepository.GetAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _bookRepository.GetAll().AsNoTracking();
        }
    }
}
