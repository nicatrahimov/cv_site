namespace BusinessLayer.Models.Experiences;

public record UpdateExperienceModel(
    int Id,
    string Name, 
    string Description,
    string CompanyName,
    DateTime DateFrom,
    DateTime? DateTo,
    string? FileExtension,
    byte[]? Image);