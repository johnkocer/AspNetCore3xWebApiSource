using Microsoft.AspNetCore.Mvc;

namespace SmartIT.V1Hi.Controllers
{
   public class HiController : ControllerBase
   {
      [Route("~/api/v1/Hi")] // Attribute routing
      [HttpGet]
      public IActionResult Get() => Content("Hi Version 1");
   }
}

namespace SmartIT.V2Hi.Controllers
{
   public class HiController : ControllerBase
   {
      [Route("~/api/v2/Hi")]// Attribute routing
      [HttpGet]
      public IActionResult Get() => Content("Hi Version 2");
   }
}


