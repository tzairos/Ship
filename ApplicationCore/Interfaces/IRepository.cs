using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces;

public interface IRepository<T> where T : class, IAggregateRoot
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetBySpesification(Spesifications.BaseSpecification<T> spec);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<int> CountAsync(ISpecification<T> spec);
}
