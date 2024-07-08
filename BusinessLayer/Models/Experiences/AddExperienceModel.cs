namespace BusinessLayer.Models.Experiences;

public record AddExperienceModel(
    string Name, 
    string Description,
    string CompanyName,
    DateTime DateFrom,
    DateTime? DateTo,
    string FileExtension,
    byte[]? Image);