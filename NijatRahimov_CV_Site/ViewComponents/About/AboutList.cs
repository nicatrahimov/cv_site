using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.ViewComponents.About;

public class AboutList(IAboutService aboutService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var abouts = await aboutService.GetAllAsync();
        return View(abouts);
    }
}