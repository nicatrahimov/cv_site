using BusinessLayer.Abstract;
using BusinessLayer.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NijatRahimov_CV_Site.Requests.Services;

namespace NijatRahimov_CV_Site.Controllers;

[Authorize(Roles = "Admin")]
[Route("/services")]
public class ServiceController(IServiceService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        var allAsync = await service.GetAllAsync();
        return View(allAsync);
    }
    
    [HttpGet("add")]
    public async Task<IActionResult> AddService()
    {
        return View();
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddService(CreateServiceRequest createServiceRequest)
    {
        if (ModelState.IsValid)
        {
            byte[]? image = null;

            string? fileExtension = null;

            var file = createServiceRequest.Image;

            if (file != null)
            {
                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);

                image = memoryStream.ToArray();

                fileExtension = Path.GetExtension(file.FileName);
            }

            var addAboutModel = new AddServiceModel(
                createServiceRequest.Title,
                fileExtension,
                image);

            await service.AddAsync(addAboutModel);

            return RedirectToAction("Index");
        }
        throw new Exception();
    }
    
    [HttpGet("delete/{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        await service.DeleteAsync(id);
        
        return RedirectToAction("Index");
    }
    
    [HttpGet("update/{id}")]
    public async Task<IActionResult> UpdateService(int id)
    {
        var getServiceModel = await service.GetByIdAsync(id);

        var updateServiceModel = new UpdateServiceModel(
            id,
            getServiceModel.Title, 
            null,
            null);

        return View(updateServiceModel);
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> UpdateService(UpdateServiceRequest updateServiceRequest)
    {
        if (ModelState.IsValid)
        {
            byte[]? image = null;

            string? fileExtension = null;

            var file = updateServiceRequest.Image;
    
            if (file != null)
            {
                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);

                image = memoryStream.ToArray();

                fileExtension = Path.GetExtension(file.FileName);
            }

            var updateServiceModel = new UpdateServiceModel(
                updateServiceRequest.Id,
                updateServiceRequest.Title,
                fileExtension,
                image);

            await service.UpdateAsync(updateServiceModel);

            return RedirectToAction("Index");
        }

        throw new Exception();
    }
}