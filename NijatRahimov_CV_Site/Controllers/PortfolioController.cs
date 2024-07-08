using BusinessLayer.Abstract;
using BusinessLayer.Models.Portfolios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NijatRahimov_CV_Site.Requests.Portfolios;

namespace NijatRahimov_CV_Site.Controllers;

[Authorize(Roles = "Admin")]
[Route("/portfolios")]
public class PortfolioController(IPortfolioService portfolioService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var allAsync = await portfolioService.GetAllAsync();
        return View(allAsync);
    }
    
    [HttpGet("add")]
    public async Task<IActionResult> AddPortfolio()
    {
        return View();
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddPortfolio(CreatePortfolioRequest createPortfolioRequest)
    {
        if (ModelState.IsValid)
        {
            byte[]? image = null;

            string? fileExtension = null;

            var file = createPortfolioRequest.Image;

            if (file != null)
            {
                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);

                image = memoryStream.ToArray();

                fileExtension = Path.GetExtension(file.FileName);
            }

            var addPortfolioModel = new AddPortfolioModel(
                createPortfolioRequest.Name,
                createPortfolioRequest.Link,
                createPortfolioRequest.Title,
                fileExtension, 
                image);

            await portfolioService.AddAsync(addPortfolioModel);

            return RedirectToAction("Index");
        }
        throw new Exception();
    }
    
    [HttpGet("update/{id}")]
    public async Task<IActionResult> UpdatePortfolio(int id)
    {
        var getPortfolioModel = await portfolioService.GetByIdAsync(id);

        var updateServiceModel = new UpdatePortfolioModel(
            id,
            getPortfolioModel.Name, 
            getPortfolioModel.Link,
            getPortfolioModel.Title,
            null,
            null);

        return View(updateServiceModel);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdatePortfolio(UpdatePortfolioRequest updatePortfolioRequest)
    {
        if (ModelState.IsValid)
        {
            byte[]? image = null;

            string? fileExtension = null;   

            var file = updatePortfolioRequest.Image;
    
            if (file != null)
            {
                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);

                image = memoryStream.ToArray();

                fileExtension = Path.GetExtension(file.FileName);
            }

            var updatePortfolioModel = new UpdatePortfolioModel(
                updatePortfolioRequest.Id,
                updatePortfolioRequest.Name,
                updatePortfolioRequest.Link,
                updatePortfolioRequest.Title,
                fileExtension,
                image);

            await portfolioService.UpdateAsync(updatePortfolioModel);

            return RedirectToAction("Index");
        }

        throw new Exception();
    }
    
    
    [HttpGet("delete/{id}")]
    public async Task<IActionResult> DeletePortfolio(int id)
    {
        await portfolioService.DeleteAsync(id);
        
        return RedirectToAction("Index");
    }
}