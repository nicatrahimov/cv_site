using BusinessLayer.Abstract;
using BusinessLayer.Models.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NijatRahimov_CV_Site.Requests.Abouts;

namespace NijatRahimov_CV_Site.Controllers;

[Authorize(Roles = "Admin")]
[Route("/abouts")]
public class AboutController(IAboutService aboutService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var abouts = await aboutService.GetAllAsync();

        return View(abouts);
    }

    [HttpGet("add")]
    public IActionResult AddAbout()
    {
        return View();
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddAbout(CreateAboutRequest createAboutRequest)
    {
        if (ModelState.IsValid && await aboutService.GetAllAsync() is { Count: 0 })
        {
            byte[]? image = null;

            string? fileExtension = null;

            var file = createAboutRequest.Image;

            if (file != null)
            {
                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);

                image = memoryStream.ToArray();

                fileExtension = Path.GetExtension(file.FileName);
            }

            var addAboutModel = new AddAboutModel(
                createAboutRequest.Title,
                createAboutRequest.Description,
                createAboutRequest.Age,
                createAboutRequest.Mail,
                createAboutRequest.Phone,
                createAboutRequest.Address,
                fileExtension,
                image);

            await aboutService.AddAsync(addAboutModel);

            return RedirectToAction("Index");
        }

        throw new Exception();
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> DeleteAbout(int id)
    {
        await aboutService.DeleteAsync(id);

        return RedirectToAction("Index");
    }

    [HttpGet("update/{id}")]
    public async Task<IActionResult> UpdateAbout(int id)
    {
        var about = await aboutService.GetByIdAsync(id);

        var updateAboutModel = new UpdateAboutModel(
            id,
            about.Title,
            about.Description,
            about.Age,
            about.Mail,
            about.Phone,
            about.Address,
            null,
            null);

        return View(updateAboutModel);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAbout(UpdateAboutRequest updateAboutRequest)
    {
        if (ModelState.IsValid)
        {
            byte[]? image = null;

            string? fileExtension = null;

            var file = updateAboutRequest.Image;

            if (file != null)
            {
                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);

                image = memoryStream.ToArray();

                fileExtension = Path.GetExtension(file.FileName);
            }

            var updateAboutModel = new UpdateAboutModel(
                updateAboutRequest.Id,
                updateAboutRequest.Title,
                updateAboutRequest.Description,
                updateAboutRequest.Age,
                updateAboutRequest.Mail,
                updateAboutRequest.Phone,
                updateAboutRequest.Address,
                fileExtension,
                image);

            await aboutService.UpdateAsync(updateAboutModel);

            return RedirectToAction("Index");
        }

        throw new Exception();
    }
}