using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AttributeBasedRouting
{
   [Produces("application/json")]
   //[Route("api/[controller]/[action]")]
   [Route("api/[controller]/[action]/{id?}")]
   public class HiController : Controller
   {
      // GET api/hi/get
      [HttpGet]
      public IEnumerable<string> Get()
      {
         return new string[] { "hi1", "hi2" };
      }

      // GET api/hi/getById/5
      [HttpGet]
      public string GetById(int id)
      {
         return "HI - " + id.ToString();
      }

      //POST api/hi/post/
      // application/json - body "Hello"
      [HttpPost]
      public string Post([FromBody]string value)
      {
         return value;
      }

      // PUT api/hi/put/5
      // application/json - body "Hello"
      [HttpPut]
      public string Put(int id, [FromBody]string value)
      {
         return value;
      }

      // DELETE api/hi/delete/5
      [HttpDelete]
      public string Delete(int id)
      {
         return id.ToString();
      }
   }
}
