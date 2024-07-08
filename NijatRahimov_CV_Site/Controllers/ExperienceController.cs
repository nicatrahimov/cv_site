using BusinessLayer.Abstract;
using BusinessLayer.Models.Experiences;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NijatRahimov_CV_Site.Requests.Experiences;

namespace NijatRahimov_CV_Site.Controllers;

[Authorize(Roles = "Admin")]
[Route("/experiences")]
public class ExperienceController(IExperienceService experienceService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var experiences = await experienceService.GetAllAsync();
        return View(experiences);
    }

    [HttpGet("add")]
    public async Task<IActionResult> AddExperience()
    {
        return View();
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddExperience(CreateExperienceRequest createExperienceRequest)
    {
        if (ModelState.IsValid)
        {
            byte[]? image = null;

            string? fileExtension = null;

            var file = createExperienceRequest.Image;

            if (file != null)
            {
                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);

                image = memoryStream.ToArray();

                fileExtension = Path.GetExtension(file.FileName);
            }

            var addAboutModel = new AddExperienceModel(
                createExperienceRequest.Name,
                createExperienceRequest.Description,
                createExperienceRequest.CompanyName,
                createExperienceRequest.DateFrom.ToUniversalTime(),
                createExperienceRequest.DateTo?.ToUniversalTime(),
                fileExtension,
                image);

            await experienceService.AddAsync(addAboutModel);

            return RedirectToAction("Index");
        }
        throw new Exception();
    }
    
    [HttpGet("delete/{id}")]
    public async Task<IActionResult> DeleteExperience(int id)
    {
        await experienceService.DeleteAsync(id);
        
        return RedirectToAction("Index");
    }
    
    [HttpGet("update/{id}")]
    public async Task<IActionResult> UpdateExperience(int id)
    {
        var getServiceModel = await experienceService.GetByIdAsync(id);

        var updateServiceModel = new UpdateExperienceModel(
            id,
            getServiceModel.Name,
            getServiceModel.Description,
            getServiceModel.CompanyName,
            getServiceModel.DateFrom,
            getServiceModel.DateTo,
            null,
            null);

        return View(updateServiceModel);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateExperience(UpdateExperienceRequest updateExperienceRequest)
    {
        if (ModelState.IsValid)
        {
            byte[]? image = null;

            string? fileExtension = null;

            var file = updateExperienceRequest.Image;
    
            if (file != null)
            {
                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);

                image = memoryStream.ToArray();

                fileExtension = Path.GetExtension(file.FileName);
            }

            var updateServiceModel = new UpdateExperienceModel(
                updateExperienceRequest.Id,
                updateExperienceRequest.Name,
                updateExperienceRequest.Description,
                updateExperienceRequest.CompanyName,
                updateExperienceRequest.DateFrom.ToUniversalTime(),
                updateExperienceRequest.DateTo?.ToUniversalTime(),
                fileExtension,
                image);

            await experienceService.UpdateAsync(updateServiceModel);

            return RedirectToAction("Index");
        }

        throw new Exception();
    }
}