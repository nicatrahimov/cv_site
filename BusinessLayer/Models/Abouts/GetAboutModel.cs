namespace BusinessLayer.Models.About;

public record GetAboutModel(
    int Id,
    string Title, 
    string Description, 
    string Age, 
    string Mail, 
    string Phone,
    string Address,
    byte[]? Image);