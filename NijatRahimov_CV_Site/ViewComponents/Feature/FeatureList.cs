using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.ViewComponents.Feature;

public class FeatureList(IFeatureService featureService) : ViewComponent
{
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var features = await featureService.GetAllAsync();
        return View(features);
    }   
}