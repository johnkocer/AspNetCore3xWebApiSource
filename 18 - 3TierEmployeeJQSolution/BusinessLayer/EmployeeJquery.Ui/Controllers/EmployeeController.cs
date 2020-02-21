using BusinessLayer.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeJquery.Ui.Controllers
{
   [Produces("application/json")]
   [ApiController]
   [Route("api/Employee")]
   public class EmployeeController : ControllerBase
   {
      private EmployeeDataContext _context;

      //private EmployeeRepository db = new EmployeeRepository();
      public EmployeeController(EmployeeDataContext context)
      {
         _context = context;
      }

      [Route("~/api/GetEmployees")]
      [HttpGet]
      public IEnumerable<Employee> GetEmployees()
      {
         return _context.Employee;// db.GetAll();
      }

      [HttpGet("{id}")]
      public Employee Get(int id)
      {
         return _context.Employee.Find(id);
      }

      [Route("~/api/AddEmployee")]
      [HttpPost]
      public IActionResult AddEmployee([FromBody]Employee obj)
      {
         _context.Employee.Add(obj);
         _context.SaveChanges();
         return new ObjectResult("Employee added successfully!");
      }

      [Route("~/api/UpdateEmployee")]
      [HttpPut]
      public IActionResult UpdateEmployee([FromBody]Employee obj)
      {
         _context.Employee.Update(obj);
         _context.SaveChanges();
         return new ObjectResult("Employee modified successfully!");
      }

      [Route("~/api/DeleteEmployee/{id}")]
      [HttpDelete]
      public IActionResult Delete(int id)
      {
         _context.Employee.Remove(_context.Employee.Find(id));
         _context.SaveChanges();
         return new ObjectResult("Employee deleted successfully!");
      }
   }
}