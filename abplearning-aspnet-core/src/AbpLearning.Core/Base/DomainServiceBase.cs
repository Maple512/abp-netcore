namespace AbpLearning.Core.Base
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Entities;
    using Abp.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;

    public abstract class 
        DomainServiceBase<T, TPrimaryKey> : IDomainServiceBase<T, TPrimaryKey>
        where T : Entity<TPrimaryKey>
    {
        protected readonly IRepository<T, TPrimaryKey> _repository;

        protected DomainServiceBase(
            IRepository<T, TPrimaryKey> bookRepository)
        {
            _repository = bookRepository;
        }

        public virtual async Task CreateOrUpdateAsync(T entity)
        {
            await _repository.InsertOrUpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(TPrimaryKey id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task BatchDeleteAsync(IEnumerable<TPrimaryKey> ids)
        {
            await _repository.DeleteAsync(m => ids.Contains(m.Id));
        }

        public virtual Task<T> GetAsync(TPrimaryKey id)
        {
            return _repository.GetAsync(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _repository.GetAll().AsNoTracking();
        }
    }
}
