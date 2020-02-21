using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
   public class EmployeeDataContext : DbContext
   {
      public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options) : base(options)
      {
      }

      public DbSet<Employee> Employee { get; set; }
   }
}