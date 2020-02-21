using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models
{
   public class Employee : IBaseEntity
   {
      [Key]
      public int Id { get; set; }

      public string Name { get; set; }
      public string Gender { get; set; }
      public int? Salary { get; set; }
      public int? DepartmentId { get; set; }

      //public Department Department { get; set; }
   }
}