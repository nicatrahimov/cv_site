namespace BusinessLayer.Models.Testimonials;

public record UpdateTestimonialModel(
    int Id,
    string ClientName,
    string CompanyName, 
    string Comment, 
    string? FileExtension,
    byte[]? Image);