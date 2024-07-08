using BusinessLayer.Abstract;
using BusinessLayer.Models.Testimonials;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NijatRahimov_CV_Site.Requests.Testimonials;

namespace NijatRahimov_CV_Site.Controllers;

[Authorize(Roles = "Admin")]
[Route("/testimonials")]
public class TestimonialController(ITestimonialService testimonialService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var testimonials = await testimonialService.GetAllAsync();
        return View(testimonials);
    }

    [HttpGet("add")]
    public async Task<IActionResult> AddTestimonial()
    {
        return View();
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddTestimonial(CreateTestimonialRequest createTestimonialRequest)
    {
        if (ModelState.IsValid)
        {
            byte[]? image = null;

            string? fileExtension = null;

            var file = createTestimonialRequest.Image;

            if (file != null)
            {
                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);

                image = memoryStream.ToArray();

                fileExtension = Path.GetExtension(file.FileName);
            }

            var addAboutModel = new AddTestimonialModel(
                createTestimonialRequest.ClientName,
                createTestimonialRequest.CompanyName,
                createTestimonialRequest.Comment,
                fileExtension,
                image);

            await testimonialService.AddAsync(addAboutModel);

            return RedirectToAction("Index");
        }

        throw new Exception();
    }

    [HttpGet("update/{id}")]
    public async Task<IActionResult> UpdateTestimonial(int id)
    {
        var getTestimonialModel = await testimonialService.GetByIdAsync(id);

        var updateServiceModel = new UpdateTestimonialModel(
            id,
            getTestimonialModel.ClientName,
            getTestimonialModel.CompanyName,
            getTestimonialModel.Comment,
            null,
            null);

        return View(updateServiceModel);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialRequest updateTestimonialRequest)
    {
        if (ModelState.IsValid)
        {
            byte[]? image = null;

            string? fileExtension = null;

            var file = updateTestimonialRequest.Image;

            if (file != null)
            {
                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);

                image = memoryStream.ToArray();

                fileExtension = Path.GetExtension(file.FileName);
            }

            var updateServiceModel = new UpdateTestimonialModel(
                updateTestimonialRequest.Id,
                updateTestimonialRequest.ClientName,
                updateTestimonialRequest.CompanyName,
                updateTestimonialRequest.Comment,
                fileExtension,
                image);

            await testimonialService.UpdateAsync(updateServiceModel);

            return RedirectToAction("Index");
        }

        throw new Exception();
    }
}