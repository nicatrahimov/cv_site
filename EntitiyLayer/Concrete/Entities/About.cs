using System.ComponentModel.DataAnnotations;

namespace EntitiyLayer.Concrete;

public class About
{
    [Key]
    public int AboutId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Age { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; } 
    public string ImageUrl { get; set; }
    
    public About(string title, string description, string age, string mail, string phone, string address, string imageUrl)
    {
        Title = title;
        Description = description;
        Age = age;
        Mail = mail;
        Phone = phone;
        Address = address;
        ImageUrl = imageUrl;
    }
}