using System.Collections.Immutable;

namespace BusinessLayer.Abstract;

public interface IGenericService<T> where T : class
{
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
    Task<IImmutableList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
}  