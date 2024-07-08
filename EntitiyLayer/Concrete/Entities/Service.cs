using System.ComponentModel.DataAnnotations;

namespace EntitiyLayer.Concrete;

public class Service
{
    [Key]
    public int ServiceId { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    
    public Service(string title, string imageUrl)
    {
        Title = title;
        ImageUrl = imageUrl;
    }
}