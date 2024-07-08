namespace BusinessLayer.Abstract;

public interface IAccessService
{
    Task<bool> ValidateUserAsync(string username, string password);
}