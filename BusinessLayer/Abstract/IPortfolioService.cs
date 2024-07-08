using System.Collections.Immutable;
using BusinessLayer.Models.Portfolios;

namespace BusinessLayer.Abstract;

public interface IPortfolioService 
{
    Task AddAsync(AddPortfolioModel getPortfolioModel);
    Task DeleteAsync(int id);
    Task UpdateAsync(UpdatePortfolioModel updatePortfolioModel);
    Task<IImmutableList<GetPortfolioModel>> GetAllAsync();
    Task<GetPortfolioModel> GetByIdAsync(int id);
}  