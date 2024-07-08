using System.Collections.Immutable;

namespace DataAccessLayer.Abstract;

public interface IGenericDal <T> where T : class
{
    Task Insert(T entity);
    Task Delete(T entity);
    Task Update(T entity);
    Task<IImmutableList<T>> GetAll();
    Task<T?> GetById(int id);
}