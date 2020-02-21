using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace SmartIt.Security.Jwt.Controllers
{
  [Authorize(Policy = "Member")]
   [ApiController]
   [Route("sales")]
   public class SalesController:ControllerBase
    {
      [HttpGet]
      public IActionResult Get()
      {
         var dictionary = new Dictionary<string, string>();
         HttpContext.User.Claims.ToList().ForEach(item => dictionary.Add(item.Type, item.Value));

         return Ok(dictionary);
      }
   }
}
