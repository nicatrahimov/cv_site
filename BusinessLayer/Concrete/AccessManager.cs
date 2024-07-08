using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;

namespace BusinessLayer.Concrete;

public class AccessManager(IUserDal userDal) : IAccessService
{
    public async Task<bool> ValidateUserAsync(string username, string password)
    {
        var users = await userDal.GetAllUsersAsync();
        return users.Any(x => x.Username.TrimEnd() == username && x.Password.TrimEnd() == password);
    }
}