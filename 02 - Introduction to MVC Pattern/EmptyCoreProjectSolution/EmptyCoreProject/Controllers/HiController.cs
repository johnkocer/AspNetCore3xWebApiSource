using EmptyCoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmptyCoreProject.Controllers
{
   public class HiController : Controller
   {
      public ActionResult Index()
      {
         return View(new Hi());
      }
   }
}