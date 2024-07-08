using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.ViewComponents.Portfolio;

public class PortfolioList(IPortfolioService portfolioService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var portfolios = await portfolioService.GetAllAsync();
        return View(portfolios);
    }
}