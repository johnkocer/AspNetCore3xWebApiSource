using System.Collections.Generic;  
using Microsoft.AspNetCore.Mvc;  
using SmartIT.Employee.MockDB;  
  
namespace HtmlPageStartUp
{
   [Produces("application/json")]
   [Route("api/Employee")]
   public class EmployeeController : Controller
   {

      private EmployeeRepository db = new EmployeeRepository();

      [Route("~/api/GetEmployees")]
      [HttpGet]
      public ICollection<Employee> GetEmployees()
      {
         return db.GetAll();
      }

      [HttpGet("{id}")]
      public Employee Get(int id)
      {
         return db.FindbyId(id);
      }

      [Route("~/api/AddEmployee")]
      [HttpPost]
      public IActionResult AddEmployee([FromBody]Employee obj)
      {
         db.Add(obj);
         return new ObjectResult("Employee added successfully!");
      }

      [Route("~/api/UpdateEmployee")]
      [HttpPut]
      public IActionResult UpdateEmployee([FromBody]Employee obj)
      {
         db.Update(obj);
         return new ObjectResult("Employee modified successfully!");
      }

      [Route("~/api/DeleteEmployee/{id}")]
      [HttpDelete]
      public IActionResult Delete(int id)
      {
         db.Delete(db.FindbyId(id));
         return new ObjectResult("Employee deleted successfully!");
      }
   }
}