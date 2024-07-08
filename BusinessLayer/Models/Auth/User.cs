namespace BusinessLayer.Models.Auth;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool KeepLoggedIn { get; set; }
}