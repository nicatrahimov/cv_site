using BusinessLayer.Abstract;
using EntitiyLayer.Concrete;
using EntityLayer.Concrete.Entities;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.Controllers;

[Route("/main")]
public class DefaultController(IMessageService service) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public PartialViewResult HeaderPartial()
    {
        return PartialView();
    }

    public PartialViewResult NavbarPartial()
    {
        return PartialView();
    }
    
    [HttpPost]
    public PartialViewResult SendMessagePartial(Message message)
    {
        service.AddAsync(message);
        return PartialView();
    }
}