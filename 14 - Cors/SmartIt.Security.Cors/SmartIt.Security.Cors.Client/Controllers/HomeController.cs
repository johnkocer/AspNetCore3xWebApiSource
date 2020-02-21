using Microsoft.AspNetCore.Mvc;

namespace SmartIt.Security.Cors.Client.Controllers
{
   public class HomeController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}