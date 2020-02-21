using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SaAuthorizationClaim.Controllers
{
   public class HomeController : Controller
   {
      [Authorize]
      public IActionResult Index()
      {
         return View();
      }

      // GET: api/Employee
      [Authorize(Policy = "SystemAdmin")]
      [Route("~/api/GetSystemAdmin")]
      [HttpGet]
      public string GetSystemAdmin()
      {
         return "SystemAdmin";
      }

      [Authorize(Policy = "SiteAdmin")]
      [Route("~/api/GetSiteAdmin")]
      [HttpGet]
      public string GetSiteAdmin()
      {
         return "SiteAdmin";
      }

      // GET: api/Employee
      [Authorize(Policy = "User")]
      [Route("~/api/GetUser")]
      [HttpGet]
      public string GetUser()
      {
         return "User";
      }

      [AllowAnonymous]
      [Route("~/api/GetAll")]
      [HttpGet]
      public string GetAll()
      {
         return "Everybody";
      }
   }
}