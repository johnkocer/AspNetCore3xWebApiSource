using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SaAuthentication.Controllers
{
   public class HomeController : Controller
   {
      [Authorize]
      public IActionResult Index()
      {
         return View();
      }
   }
}