using Microsoft.AspNetCore.Mvc;

namespace WebAppVersioningMicrosoft.Controllers
{
   // via HTTP header with only method mapped to different version
   // e.g. /api/payment, add api-version header

   [ApiVersion("1.0")]
   [ApiVersion("2.0")]
   [ApiController]
   [Route("api/payment")]
   public class PaymentController : ControllerBase
   {
      [HttpGet]
      public IActionResult Get() => Content("Version 1");

      [HttpGet, MapToApiVersion("2.0")]
      public IActionResult GetV2() => Content("Version 2");
   }
}