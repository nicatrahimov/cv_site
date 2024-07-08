using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Testimonial
{
    [Key]
    public int TestimonialId { get; set; }
    public string ClientName { get; set; }
    public string CompanyName { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    
    public Testimonial(string clientName, string companyName, string comment, string imageUrl)
    {
        ClientName = clientName;
        CompanyName = companyName;
        Comment = comment;
        ImageUrl = imageUrl;
    }
}