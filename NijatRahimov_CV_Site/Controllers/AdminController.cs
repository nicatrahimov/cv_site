using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public PartialViewResult PartialSideBar()
    {
        return PartialView();
    }
}