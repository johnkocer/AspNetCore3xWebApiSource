using Microsoft.AspNetCore.Mvc;

namespace BasicRouting
{
   [Produces("application/json")]
   public class HomeController : Controller
   {
      //to call http://localhost:54263/home/index
      public IActionResult Index()
      {
         return Content("Home/Index");
      }

      //to call http://localhost:54263/home/viewone
      public IActionResult ViewOne()
      {
         return Content("Home/One");
      }

      //to call http://localhost:54263/home/viewtwo
      [HttpGet]
      public IActionResult ViewTwo()
      {
         return Content("GET-Home/Two");
      }

      //to call http://localhost:54263/home/viewtwo/6
      [HttpPost]
      public IActionResult ViewTwo(int id)
      {
         return Content($"POST-Home:{id}");
      }
   }
}