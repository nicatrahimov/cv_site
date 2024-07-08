using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.ViewComponents.Skill;

public class SkillList(ISkillService skillService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var skills = await skillService.GetAllAsync();
        return View(skills);
    }
}