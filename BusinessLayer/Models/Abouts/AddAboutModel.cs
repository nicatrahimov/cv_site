namespace BusinessLayer.Models.About;

public record AddAboutModel(
    string Title, 
    string Description,
    string Age, 
    string Mail,
    string Phone,
    string Address, 
    string? FileExtension,
    byte[]? Image);