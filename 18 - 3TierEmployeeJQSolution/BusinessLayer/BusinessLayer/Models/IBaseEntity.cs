using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models
{
   public interface IBaseEntity
   {
      [Key]
      int Id { get; set; }
   }
}