namespace BusinessLayer.Models.Services;

public record UpdateServiceModel(int Id, string Title, string? FileExtension, byte[]? Image);