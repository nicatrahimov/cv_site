using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.Controllers;

[Route("/messages")]
public class MessageController(IMessageService messageService) : Controller
{
    public async Task<ViewResult> Index()
    {
        var messages = await messageService.GetAllAsync();
        return View(messages);
    }
    
    [HttpGet("{messageId}")]
    public ActionResult MarkMessageAsRead(int messageId)
    { 
        messageService.MarkMessageAsRead(messageId);
        return RedirectToAction("Index");
    }
}