using System.Collections.Immutable;
using EntitiyLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccesLayer.Abstract;

public interface IUserDal
{
    Task<IImmutableList<User>> GetAllUsersAsync();
    Task<User?> GetUserByUsernameAsync(string username);  
}   