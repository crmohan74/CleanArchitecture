using System.Linq.Expressions;
using SampleProject.Core.Entities;

namespace SampleProject.Core.Repositories;

public interface IAsyncRepository<T> where T: EntityBase
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}