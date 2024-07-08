namespace BusinessLayer.Models.Portfolios;

public record UpdatePortfolioModel(int Id, string Name, string Link, string Title, string FileExtension, byte[]? Image);