using BusinessLayer.Abstract;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.Controllers;

[Authorize(Roles = "Admin")]
[Route("/features")]
public class FeatureController(IFeatureService featureService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var features = await featureService.GetAllAsync();
        return View(features);
    }
    
    [HttpGet("add")]
    public IActionResult AddFeature()
    {
        return View();
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddFeature(Feature feature)
    {
        await featureService.AddAsync(feature);
        return RedirectToAction("Index");
    } 
    
    [HttpGet("delete/{id}")]
    public async Task<IActionResult> DeleteFeature(int id)
    {
        var feature = await featureService.GetByIdAsync(id);
        await featureService.DeleteAsync(feature);
        return RedirectToAction("Index");
    }
    
    [HttpGet("update/{id}")]
    public async Task<IActionResult> UpdateFeature(int id)
    {
        var feature = await featureService.GetByIdAsync(id);
        return View(feature);
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> UpdateFeature(Feature feature)
    {
        await featureService.UpdateAsync(feature);
        return RedirectToAction("Index");
    }
}