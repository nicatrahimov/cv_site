using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.ViewComponents.Service;

public class ServiceList(IServiceService serviceService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var services = await serviceService.GetAllAsync();
        return View(services);
    }
}