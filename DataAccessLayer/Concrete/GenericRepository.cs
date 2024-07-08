using System.Collections.Immutable;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete;

public class GenericRepository<T> : IGenericDal<T>
    where T : class
{
    public async Task Insert(T entity)
    {
        var context = new Context();
        context.Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        var context = new Context();
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        var context = new Context();
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public Task<IImmutableList<T>> GetAll()
    {
        var context = new Context();
        return Task.FromResult<IImmutableList<T>>(context.Set<T>().ToImmutableList());
    }

    public Task<T?> GetById(int id)
    {
        var context = new Context();
        return Task.FromResult(context.Set<T>().Find(id));
    }
}