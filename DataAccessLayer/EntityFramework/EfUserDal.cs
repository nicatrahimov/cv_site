using System.Collections.Immutable;
using DataAccesLayer.Abstract;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.EntityFramework;

public class EfUserDal : IUserDal
{
    public async Task<IImmutableList<User>> GetAllUsersAsync()
    {
        var context = new Context();
        return await Task.FromResult<IImmutableList<User>>(context.Set<User>().ToImmutableList());
    }   

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        var context = new Context();
        return await context.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
    }
}