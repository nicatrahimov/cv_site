using System.ComponentModel.DataAnnotations;

namespace EntitiyLayer.Concrete;

public class Experience
{
    [Key]
    public int ExperienceId { get; set; }
    public string Name { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public string CompanyName { get; set; }
    
    public Experience(string name, DateTime dateFrom, DateTime? dateTo, string description, string companyName, string imageUrl)
    {
        Name = name;
        DateFrom = dateFrom;
        DateTo = dateTo;
        Description = description;
        CompanyName = companyName;
        ImageUrl = imageUrl;
    }
}