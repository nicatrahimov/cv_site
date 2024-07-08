using BusinessLayer.Abstract;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.Controllers;

[Authorize(Roles = "Admin")]
[Route("/skills")]
public class SkillController(ISkillService skillService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var skills = await skillService.GetAllAsync();
        return View(skills);
    }

  
    [HttpGet("add")]
    public IActionResult AddSkill()
    {
        return View();
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddSkill(Skill skill)
    {
        await skillService.AddAsync(skill);
        return RedirectToAction("Index");
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> DeleteSkill(int id)
    {
        var skill = await skillService.GetByIdAsync(id);
        await skillService.DeleteAsync(skill);
        return RedirectToAction("Index");
    }

    [HttpGet("update/{id}")]
    public async Task<IActionResult> UpdateSkill(int id)
    {
        var skill = await skillService.GetByIdAsync(id);
        return View(skill);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateSkill(Skill skill)
    {
        await skillService.UpdateAsync(skill);
        return RedirectToAction("Index");
    }
}