using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SaAuthorizationClaim.Auth
{
   public class MinimumAgeRequirementHandler : AuthorizationHandler<MinimumAgeRequirement>
   {
      protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                     MinimumAgeRequirement requirement)
      {
         if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth && c.Issuer == "http://wine.com"))
            return Task.CompletedTask;

         var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(
            c => c.Type == ClaimTypes.DateOfBirth &&
                     c.Issuer == "http://wine.com").Value);

         int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
         
         if (calculatedAge >= requirement.MinimumAge)
            context.Succeed(requirement);

         return Task.CompletedTask;
      }
   }
}