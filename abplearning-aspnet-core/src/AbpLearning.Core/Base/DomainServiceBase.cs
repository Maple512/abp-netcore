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
        protected readonly IRepository<T, TPrimaryKey> _repository;

        protected DomainServiceBase(IRepository<T, TPrimaryKey> bookRepository)
        {
            _repository = bookRepository;
        }

        public virtual Task CreateOrUpdateAsync(T entity) => _repository.InsertOrUpdateAsync(entity);

        public virtual Task InsertAsync(T entity) => _repository.InsertAsync(entity);

        public virtual Task UpdateAsync(T entity) => _repository.UpdateAsync(entity);

        public virtual Task DeleteAsync(TPrimaryKey id) => _repository.DeleteAsync(id);

        public virtual Task BatchDeleteAsync(IEnumerable<TPrimaryKey> ids) => _repository.DeleteAsync(m => ids.Contains(m.Id));

        public virtual Task<T> GetAsync(TPrimaryKey id) => _repository.GetAsync(id);

        public virtual IQueryable<T> GetAll() => _repository.GetAll().AsNoTracking();
    }
}
