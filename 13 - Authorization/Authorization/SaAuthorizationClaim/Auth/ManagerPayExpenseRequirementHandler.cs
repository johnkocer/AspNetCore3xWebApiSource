using Microsoft.AspNetCore.Authorization;
using SaAuthorizationClaim.Models.Manager;
using System.Threading.Tasks;

namespace SaAuthorizationClaim.Auth
{
   public class ManagerPayExpenseRequirementHandler : AuthorizationHandler<ManagerPayExpenseRequirement, Manager>
   {
      protected override Task HandleRequirementAsync(
          AuthorizationHandlerContext context, ManagerPayExpenseRequirement requirement,
          Manager resource)
      {
         if (!context.User.HasClaim(c => c.Type == "HasExpenseCredit"))
            return Task.CompletedTask;

         var payExpenses = bool.Parse(context.User.FindFirst("HasExpenseCredit").Value);

         if (resource.HasExpenseCredit && payExpenses)
            context.Succeed(requirement);

         return Task.CompletedTask;
      }
   }
}