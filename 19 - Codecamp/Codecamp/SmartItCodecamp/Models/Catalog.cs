using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartItCodecamp.Models
{
   public class Catalog
   {
      public int Id { get; set; }
      public int InstructorId { get; set; }
      public int CourseId { get; set; }
      public Instructor Instructor { get; set; }
      public Course Course { get; set; }

      [StringLength(50, MinimumLength = 3)]
      public string Name { get; set; }

      [DataType(DataType.Currency)]
      [Column(TypeName = "money")]
      public decimal Tuition { get; set; }

      [DataType(DataType.Date)]
      [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
      [Display(Name = "Start Date")]
      public DateTime StartDate { get; set; }


      [Timestamp]
      public byte[] RowVersion { get; set; }
   }
}