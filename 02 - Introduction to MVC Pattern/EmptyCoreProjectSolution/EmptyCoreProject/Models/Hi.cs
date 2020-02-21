namespace EmptyCoreProject.Models
{
   public class Hi
   {
      public string SayHi => "Hi " + Name;
      public string Name { get; set; } = "John";
   }
}