using Microsoft.AspNetCore.Mvc;

namespace AttributeBasedRouting
{
   [Route("Employees")]
   [Route("[controller]")]
   public class SmartItController:Controller
    {
      [HttpGet("All")]
      [HttpGet("SmartItEmployees")]
      public string GetEmployees()
      {
         return "It is multiple route example!";
      }
    }
}
