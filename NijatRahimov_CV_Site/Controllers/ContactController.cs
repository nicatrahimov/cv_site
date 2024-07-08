using BusinessLayer.Abstract;
using BusinessLayer.Models.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NijatRahimov_CV_Site.Requests.Contacts;

namespace NijatRahimov_CV_Site.Controllers;

[Authorize(Roles = "Admin")]
[Route("/contacts")]
public class ContactController(IContactService contactService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var contacts = await contactService.GetAllAsync();
        return View(contacts);
    }
    
    [HttpGet("add")]
    public async Task<IActionResult> AddContact()
    {
        return View();
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddContact(CreateContactRequest createContactRequest)
    {   
        if (!ModelState.IsValid)
        {
            var addContactModel = new AddContactModel(
                createContactRequest.Title,
                createContactRequest.Mail,
                createContactRequest.Phone
                );
            
            return View(addContactModel);
        }
        
        return RedirectToAction("Index");
    }
    
    [HttpGet("update/{id}")]
    public async Task<IActionResult> UpdateContact(int id)
    {
        var getContactModel = await contactService.GetByIdAsync(id);
        var updateContactModel = new UpdateContactModel(
            getContactModel.Id,
            getContactModel.Title,
            getContactModel.Mail,
            getContactModel.Phone
            );
            
        return View(updateContactModel);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateContact(UpdateContactRequest updateContactRequest)
    {
      var updateContactModel = new UpdateContactModel(
          updateContactRequest.Id,
          updateContactRequest.Title,
          updateContactRequest.Mail,
          updateContactRequest.Phone
          );
      
     await contactService.UpdateAsync(updateContactModel);
        return RedirectToAction("Index");}
  }