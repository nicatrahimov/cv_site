namespace BusinessLayer.Models.Testimonials;

public record GetTestimonialModel(
    int Id,
    string ClientName,
    string CompanyName, 
    string Comment, 
    byte[]? Image);