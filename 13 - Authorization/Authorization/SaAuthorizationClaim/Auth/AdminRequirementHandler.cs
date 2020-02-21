using Microsoft.AspNetCore.Authorization;
using SaAuthorizationClaim.Models.Manager;
using SaAuthorizationClaim.Models.Security;
using System.Threading.Tasks;

namespace SaAuthorizationClaim.Auth
{
   public class AdminRequirementHandler : AuthorizationHandler<AdminRequirement, Admin>
   {
      protected override Task HandleRequirementAsync(
          AuthorizationHandlerContext context, AdminRequirement requirement,
          Admin resource)
      {
         if (!context.User.HasClaim(c => c.Type == Roles.Admin.ToString()))
            return Task.CompletedTask;

         var isAdmin = context.User.FindFirst("Admin").Value;
         if (!string.IsNullOrEmpty(isAdmin))
            context.Succeed(requirement);

         return Task.CompletedTask;
      }
   }
}