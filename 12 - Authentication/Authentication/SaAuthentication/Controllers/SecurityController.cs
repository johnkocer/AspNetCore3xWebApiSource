using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SaAuthentication.Model.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SaAuthentication.Controllers
{
  public class SecurityController : Controller
  {
    public IActionResult Login(string requestPath)
    {
      ViewBag.RequestPath = requestPath ?? "/";
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginInputModel inputModel)
    {
      if (!IsAuthentic(inputModel.Username, inputModel.Password))
        return View();

      // Create claims
      List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Bob Rich"),
                new Claim(ClaimTypes.Email, inputModel.Username)
            };

      // Create identity
      ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

      // Create principal
      ClaimsPrincipal principal = new ClaimsPrincipal(identity);

      // Sign-in
      await HttpContext.SignInAsync(
              scheme: "SaSecurityScheme",
              principal: principal,
              properties: new AuthenticationProperties
              {
                   //IsPersistent = true, // for 'remember me' feature
                   //ExpiresUtc = DateTime.UtcNow.AddMinutes(15)
                 });

      return Redirect(inputModel.RequestPath ?? "/");
      //return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout(string requestPath)
    {
      await HttpContext.SignOutAsync(
              scheme: "SaSecurityScheme");

      return RedirectToAction("Login");
    }

    public IActionResult Access()
    {
      return View();
    }

    private bool IsAuthentic(string userName, string password)
    {
      return (userName == "john" && password == "hello");
    }
  }
}