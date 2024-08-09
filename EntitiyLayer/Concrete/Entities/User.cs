using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class User
{
    [Key]
    public string Username { get; set; } 
    public string Password { get; set; }
    
    public User(string username, string password)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Password = password ?? throw new ArgumentNullException(nameof(password));
    }
}