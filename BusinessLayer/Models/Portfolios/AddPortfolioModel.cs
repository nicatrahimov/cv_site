namespace BusinessLayer.Models.Portfolios;

public record AddPortfolioModel(string Name, string Link, string Title, string? FileExtension,byte[]? Image);