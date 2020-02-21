using System;
using System.Linq;
using SmartItCodecamp.Models;

namespace SmartItCodecamp.Data
{
   public static class DbInitializer
   {
      public static void Initialize(DataContext context)
      {
         context.Database.EnsureCreated();

         // Look for any students.
         if (context.Students.Any())
         {
            return;   // DB has been seeded
         }

         var students = new Student[]
         {
                new Student { FirstName = "Bob",   LastName = "Wood",
                    EnrollmentDate = DateTime.Parse("2018-01-01") },
                new Student { FirstName = "Jennifer", LastName = "Smith",
                    EnrollmentDate = DateTime.Parse("2017-09-01") },
                new Student { FirstName = "Artur",   LastName = "Runner",
                    EnrollmentDate = DateTime.Parse("2017-09-01") },
                new Student { FirstName = "Mike",    LastName = "Gold",
                    EnrollmentDate = DateTime.Parse("2012-09-01") }
         };

         foreach (Student s in students)
         {
            context.Students.Add(s);
         }
         context.SaveChanges();

         var instructors = new Instructor[]
         {
                new Instructor { FirstName = "Kim",     LastName = "Smart",
                    HireDate = DateTime.Parse("2005-03-11") },
                new Instructor { FirstName = "John",    LastName = "Patman",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstName = "Cindy",   LastName = "Edison",
                    HireDate = DateTime.Parse("2014-07-01") },
                new Instructor { FirstName = "Nancy", LastName = "Jiggle",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstName = "Cindy",   LastName = "Carter",
                    HireDate = DateTime.Parse("2004-02-12") }
         };

         foreach (Instructor i in instructors)
         {
            context.Instructors.Add(i);
         }
         context.SaveChanges();


         var courses = new Course[]
         {
                new Course {Id = 1050, Title = "Entity Framework",      Grade = 1},
                new Course {Id = 4022, Title = "C-Sharp", Grade = 1
                },
                new Course {Id = 4041, Title = "SQL", Grade = 1
                }
         };

         foreach (Course c in courses)
         {
            context.Courses.Add(c);
         }
         context.SaveChanges();


         var catalog = new Catalog[]
         {
                new Catalog {Name = "Entity Framework", Tuition = 1000, StartDate = DateTime.Parse("2007-09-01"), CourseId = courses.Single(c => c.Title == "Entity Framework" ).Id, InstructorId = instructors.Single(i => i.LastName == "Edison").Id },
                new Catalog { Name = "C-Sharp", Tuition = 1000, StartDate = DateTime.Parse("2007-09-01"), CourseId = courses.Single(c => c.Title == "C-Sharp" ).Id, InstructorId = instructors.Single(i => i.LastName == "Carter").Id }
         };

         foreach (Catalog ci in catalog)
         {
            context.Catalog.Add(ci);
         }
         context.SaveChanges();
      }
   }
}