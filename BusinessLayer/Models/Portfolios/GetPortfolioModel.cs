namespace BusinessLayer.Models.Portfolios;

public record GetPortfolioModel(int Id, string Name, string Link, string Title, byte[]? Image);