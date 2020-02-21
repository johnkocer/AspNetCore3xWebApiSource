using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaAuthorizationClaim.Models.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SaAuthorizationClaim.Controllers
{
   [AllowAnonymous]
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

         HttpContext.Session.SetString("userName", inputModel.Username);
         // Create claims
         var claims = GetClaims(inputModel.Username);

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

         //return Redirect(inputModel.RequestPath ?? "/");
         return RedirectToAction("Index", "Home");
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
         return !string.IsNullOrEmpty(userName);
      }

      private List<Claim> GetClaims(string username)
      {
         if (username.ToLower() == "jim")
         {
            return new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Sales Manager"),
                    new Claim("Manager", "100"),
                    new Claim("EmployeeId", "10"),
                    new Claim("CanGiveBonus", "100")
                };
         }

         if (username.ToLower() == "bill")
         {
            return new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Lead Manager"),
                    new Claim("EmployeeId", "11"),
                    new Claim("Manager", "100"),
                    new Claim("HasExpenseCredit", "true")
                };
         }

         if (username.ToLower() == "john")
         {
            return new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "SiteAdmin"),
                    new Claim("EmployeeId", "10"),
                    new Claim("SiteAdmin", "true"),
                    new Claim("UserName","john")
                };
         }

         if (username.ToLower() == "bob")
         {
            return new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "SystemAdmin"),
                    new Claim("SystemAdmin", "true")
                };
         }

         if (username.ToLower() == "joe")
         {
            return new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "User"),
                    new Claim("User", "true"),
                    new Claim(ClaimTypes.DateOfBirth, "01/01/1990")
                };
         }

         return new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Guest")
            };
      }
   }
}