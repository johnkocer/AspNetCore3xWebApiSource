using Microsoft.AspNetCore.Mvc;

namespace WebAppVersioningMicrosoft.Controllers
{
  public class SaleController
  {
  }

  // Conventions specified in Startup
  // via HTTP header
  // e.g. /api/sale, add api-version header
  [ApiController]
  [Route("api/sale")]
  public class SaleControllerV1 : ControllerBase
  {
    [HttpGet]
    public IActionResult Get() => Content("Version 1");
  }
  [ApiController]
  [Route("api/sale")]
  public class SaleControllerV2 : ControllerBase
  {
    [HttpGet]
    public IActionResult Get() => Content("Version 2");
  }
}