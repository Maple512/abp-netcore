namespace AbpLearning.Core.Base
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Domain.Entities;
    using Abp.Domain.Services;

    /// <summary>
    /// 基础领域服务接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IDomainServiceBase<T, TPrimaryKey> : IDomainService
        where T : Entity<TPrimaryKey>
    {
        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task CreateOrUpdateAsync(T entity);

        Task<TPrimaryKey> CreateOrUpdateGetIdAsync(T entity);

        Task DeleteAsync(TPrimaryKey id);

        Task BatchDeleteAsync(IEnumerable<TPrimaryKey> ids);

        Task<T> GetAsync(TPrimaryKey id);

        /// <summary>
        /// AsNoTracking
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
    }
}
