using System.Collections.Immutable;
using BusinessLayer.Abstract;
using BusinessLayer.Models.Portfolios;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;

namespace BusinessLayer.Concrete;

public class PortfolioManager(IPortfolioDal portfolioDal, IAssetsStorageService assetsStorageService) : IPortfolioService
{
    private readonly string PortfolioFolderPath = Path.Combine(assetsStorageService.GetStoragePath(), "Portfolios");

    
    public async Task AddAsync(AddPortfolioModel addPortfolioModel)
    {
        var imagePath = "";
        
        if (addPortfolioModel.Image != null && !string.IsNullOrWhiteSpace(addPortfolioModel.FileExtension))
        {
            var fileName = $"photo_{Guid.NewGuid()}{addPortfolioModel.FileExtension}";

            var filePath = Path.Combine(PortfolioFolderPath, fileName );

            await File.WriteAllBytesAsync(filePath, addPortfolioModel.Image);

            imagePath = filePath;
        }

        var service = new Portfolio(
            addPortfolioModel.Title,
            addPortfolioModel.Name,
            addPortfolioModel.Link,
            imagePath);
        
        await portfolioDal.Insert(service);
    }

    public async Task DeleteAsync(int id)
    {
        var service = await portfolioDal.GetById(id);

        if (!string.IsNullOrWhiteSpace(service?.ImageUrl))
        {
            File.Delete(service.ImageUrl);
        }

        if (service != null) await portfolioDal.Delete(service);
    }

    public async Task UpdateAsync(UpdatePortfolioModel updatePortfolioModel)
    {
        var imagePath = "";

        var existingPortfolio = await portfolioDal.GetById(updatePortfolioModel.Id);

        if (updatePortfolioModel.Image != null && !string.IsNullOrWhiteSpace(updatePortfolioModel.FileExtension))
        {
            var fileName = $"photo_{Guid.NewGuid()}{updatePortfolioModel.FileExtension}";

            var filePath = Path.Combine(PortfolioFolderPath, fileName);

            await File.WriteAllBytesAsync(filePath, updatePortfolioModel.Image);

            imagePath = filePath;

            if (!string.IsNullOrWhiteSpace(existingPortfolio.ImageUrl))
            {
                File.Delete(existingPortfolio.ImageUrl);
            }
        }
        else
        {
            if (existingPortfolio != null)
            {
                imagePath = existingPortfolio.ImageUrl;
            }
        }
        var portfolio = new Portfolio(
            updatePortfolioModel.Title,
            updatePortfolioModel.Name,
            updatePortfolioModel.Link,
            imagePath);
        
        portfolio.PortfolioId = updatePortfolioModel.Id;
        
        await portfolioDal.Update(portfolio);
    }

    public async Task<IImmutableList<GetPortfolioModel>> GetAllAsync()
    {
        var portfolios = await portfolioDal.GetAll();

        var getServiceModels = new List<GetPortfolioModel>();

        foreach (var portfolio in portfolios)
        {
            byte[]? image = null;

            if (!string.IsNullOrWhiteSpace(portfolio.ImageUrl))
            {
                image = await File.ReadAllBytesAsync(portfolio.ImageUrl);
            }
            getServiceModels.Add(new GetPortfolioModel(
                portfolio.PortfolioId, 
                portfolio.Name, 
                portfolio.Link,
                portfolio.Title,
                image));
        }

        return getServiceModels.ToImmutableList();
    }

    public async Task<GetPortfolioModel> GetByIdAsync(int id)
    {
        var portfolio = await portfolioDal.GetById(id);

        byte[]? image = null;

        if (!string.IsNullOrWhiteSpace(portfolio?.ImageUrl))
        {
            image = await File.ReadAllBytesAsync(portfolio.ImageUrl);
        }
        
        return new GetPortfolioModel(
            portfolio.PortfolioId,
            portfolio.Name,
            portfolio.Link,
            portfolio.Title,
            image);  
    }
}