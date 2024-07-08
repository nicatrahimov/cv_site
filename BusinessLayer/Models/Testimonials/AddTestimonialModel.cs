namespace BusinessLayer.Models.Testimonials;

public record AddTestimonialModel(
    string ClientName,
    string CompanyName, 
    string Comment, 
    string? FileExtension,
    byte[]? Image);