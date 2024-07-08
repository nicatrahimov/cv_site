using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.ViewComponents.Experience;

public class ExperienceList(IExperienceService experienceService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var experiences = await experienceService.GetAllAsync();
        return View(experiences);
    }
}