using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConventionBasedRouting
{
   [Produces("application/json")]
   public class HiController : Controller
   {
      // GET api/hi/get
      public IEnumerable<string> Get()
      {
         return new string[] { "hi1", "hi2" };
      }

      // GET api/hi/getById/5
      public string GetById(int id)
      {
         return "HI - " + id.ToString();
      }

      //POST api/hi/post/
      // application/json - body "Hello-POST"
      public string Post([FromBody]string value)
      {
         return value;
      }

      // PUT api/hi/put/5
      // application/json - body "Hello-PUT"
      public string Put(int id, [FromBody]string value)
      {
         return value;
      }

      // DELETE api/hi/values/5
      public string Delete(int id)
      {
         return id.ToString();
      }
   }
}
