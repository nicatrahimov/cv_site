namespace BusinessLayer.Models.Experiences;

public record GetExperienceModel(
    int Id,
    string Name, 
    string Description,
    string CompanyName,
    DateTime DateFrom,
    DateTime? DateTo,
    byte[]? Image);