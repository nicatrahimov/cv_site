using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.ViewComponents.Contact;

public class ContactDetails(IContactService contactService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var contacts = await contactService.GetAllAsync();
        return View(contacts);
    }
}