using System.ComponentModel.DataAnnotations;

namespace EntitiyLayer.Concrete;

public class Contact
{
    [Key] public int ContactId { get; set; }
    public string Title { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }

    public Contact(string title, string mail, string phone)
    {
        Title = title;
        Mail = mail;
        Phone = phone;
    }
}

