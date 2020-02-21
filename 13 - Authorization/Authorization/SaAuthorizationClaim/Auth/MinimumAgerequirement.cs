using Microsoft.AspNetCore.Authorization;

namespace SaAuthorizationClaim.Auth
{
   public class MinimumAgeRequirement : IAuthorizationRequirement
   {
      public int MinimumAge { get; set; }

      public MinimumAgeRequirement(int minimumAge)
      {
         MinimumAge = minimumAge;
      }
   }
}