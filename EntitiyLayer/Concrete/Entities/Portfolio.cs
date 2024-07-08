using System.ComponentModel.DataAnnotations;

namespace EntitiyLayer.Concrete;

public class Portfolio
{
    [Key]
    public int PortfolioId { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public string ImageUrl { get; set; }
    
    public Portfolio(string title, string name, string link, string imageUrl)
    {
        Title = title;
        Name = name;
        Link = link;
        ImageUrl = imageUrl;
    }
}