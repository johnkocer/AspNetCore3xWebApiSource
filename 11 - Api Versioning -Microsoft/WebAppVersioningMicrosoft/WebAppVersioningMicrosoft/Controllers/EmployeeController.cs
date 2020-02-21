using Microsoft.AspNetCore.Mvc;

namespace WebAppVersioningMicrosoft.Controllers
{
  // via URL
  // e.g. api/v2.0/employee/getall

  [ApiVersion("1.0")]
  [ApiController]
  [Route("api/v{ver:apiVersion}/employee/GetAll")]
  public class EmployeeControllerV1 : ControllerBase
  {
    [HttpGet]
    public IActionResult GetAll() => Content("Version 1");
  }

  [ApiVersion("2.0")]
  [ApiController]
  [Route("api/v{ver:apiVersion}/employee/GetAll")]
  public class EmployeeControllerV2 : ControllerBase
  {
    [HttpGet]
    public IActionResult GetAll() => Content("Version 2");
  }
}