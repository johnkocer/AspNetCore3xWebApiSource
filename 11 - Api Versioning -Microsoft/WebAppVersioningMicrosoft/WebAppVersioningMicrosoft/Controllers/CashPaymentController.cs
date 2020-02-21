using Microsoft.AspNetCore.Mvc;

namespace WebAppVersioningMicrosoft.Controllers
{
   // Deprecated
   // via HTTP header
   // e.g. api/cashPayment, add api-version header

   [ApiVersion("1.0", Deprecated = true)]
   [ApiController]
   [Route("api/cashPayment")]
   public class CashPaymentControllerV1 : ControllerBase
   {
      [HttpGet]
      public IActionResult Get() => Content("Version 1");
   }

   [ApiVersion("2.0")]
   [ApiController]
   [Route("api/cashPayment")]
   public class CashPaymentControllerV2 : ControllerBase
   {
      [HttpGet]
      public IActionResult Get() => Content("Version 2");
   }
}