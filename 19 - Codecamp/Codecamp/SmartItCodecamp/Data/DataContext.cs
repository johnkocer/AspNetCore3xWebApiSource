using Microsoft.EntityFrameworkCore;
using SmartItCodecamp.Models;

namespace SmartItCodecamp.Data
{
   public class DataContext : DbContext
   {
      public DataContext(DbContextOptions<DataContext> options) : base(options)
      {
      }

      public DbSet<Course> Courses { get; set; }
      public DbSet<Enrollment> Enrollments { get; set; }
      public DbSet<Student> Students { get; set; }
      public DbSet<Catalog> Catalog { get; set; }
      public DbSet<Instructor> Instructors { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Course>().ToTable("Course");
         modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
         modelBuilder.Entity<Student>().ToTable("Student");
         modelBuilder.Entity<Catalog>().ToTable("Catalog");
         modelBuilder.Entity<Instructor>().ToTable("Instructor");
      }
   }
}