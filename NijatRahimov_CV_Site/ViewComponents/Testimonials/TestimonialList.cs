using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.ViewComponents.Testimonials;

public class TestimonialList(ITestimonialService testimonialService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var testimonials = await testimonialService.GetAllAsync();
        return View(testimonials);
    }
}