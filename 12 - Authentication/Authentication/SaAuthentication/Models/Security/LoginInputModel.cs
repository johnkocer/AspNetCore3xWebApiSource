namespace SaAuthentication.Model.Security
{
   public class LoginInputModel
   {
      public string Username { get; set; }
      public string Password { get; set; }
      public string RequestPath { get; set; }
      public Roles Role { get; set; }
   }

   public enum Roles
   {
      User,
      Admin
   }
}