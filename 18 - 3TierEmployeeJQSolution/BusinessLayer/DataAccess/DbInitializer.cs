using BusinessLayer.Models;
using System.Linq;

namespace DataAccess
{
   public static class DbInitializer
   {
      public static void Initialize(EmployeeDataContext context)
      {
         context.Database.EnsureCreated();

         // Look for any employee.
         if (context.Employee.Any())
         {
            return;   // DB has been seeded
         }

         var employees = new Employee[]
         {
               //new Employee() { Id = 1, DepartmentId = 1, Gender = "Male", Name = "Mike", Salary = 8000 },
               //new Employee() { Id = 2, DepartmentId = 1, Gender = "Male", Name = "Adam", Salary = 5000 },
               //new Employee() { Id = 3, DepartmentId = 1, Gender = "Female", Name = "Jacky", Salary = 9000 }
               new Employee() {  DepartmentId = 1, Gender = "Male", Name = "Mike", Salary = 8000 },
               new Employee() {  DepartmentId = 1, Gender = "Male", Name = "Adam", Salary = 5000 },
               new Employee() {  DepartmentId = 1, Gender = "Female", Name = "Jacky", Salary = 9000 }
         };

         foreach (Employee e in employees)
         {
            context.Employee.Add(e);
         }
         context.SaveChanges();
      }
   }
}