using Microsoft.AspNetCore.Mvc;

namespace AttributeBasedRouting
{
   [Route("api/[controller]")]
    public class EmployeeController:Controller
    {
      [HttpGet("{id:int}")]
      public string GetEmployee(int id)
      {
         return id.ToString();
      }

      //[HttpGet("{id:range(18,40)}")]
      ////[HttpGet("{age:int}/{age:range(18,40)}")]
      //public string GetEmployeeAge(int id)
      //{
      //   return id.ToString();
      //}

      [HttpGet("{age:range(18,40)}")]
      //[HttpGet("{age:int}/{age:range(18,40)}")]
      public string GetEmployeeAge(int age)
      {
         return age.ToString();
      }

      [HttpGet("{name:regex(^[[a-bA-B0-2]]*$)}")]
      //[HttpGet("{age:int}/{age:range(18,40)}")]
      public string GetEmployeeNameAB12(string name)
      {
         return name.ToString();
      }
   }
}
