using System.Security.Claims;
using BusinessLayer.Abstract;
using BusinessLayer.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace NijatRahimov_CV_Site.Controllers;

public class AccessController(IAccessService accessService) : Controller
{
    public IActionResult Login()
    {
        ClaimsPrincipal claimUser = HttpContext.User;

        if (claimUser.Identity != null && claimUser.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "About");
        }
        
        return View();
    } 
    
    [HttpPost]
    public async Task<IActionResult> Login(User user)
    {
        if (await accessService.ValidateUserAsync(user.Username,user.Password))
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Username),
                new (ClaimTypes.Role, "Admin")
            };
            
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = user.KeepLoggedIn,
            };
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            
            return Redirect($"/admin");
        }

        ViewData["ValidateMessage"] = "Username or password is incorrect! Contact the owner please!";
        return View(user);
    }
}