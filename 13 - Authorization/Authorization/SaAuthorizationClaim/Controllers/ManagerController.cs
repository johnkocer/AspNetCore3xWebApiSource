using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaAuthorizationClaim.Models.Manager;
using System.Threading.Tasks;

namespace SaAuthorizationClaim.Controllers
{
   [Authorize(Policy = "Manager")]
   public class ManagerController : Controller
   {
      private readonly IAuthorizationService _authorizationService;

      public ManagerController(IAuthorizationService authorizationService)
      {
         _authorizationService = authorizationService;
      }

      public IActionResult Manager()
      {
         return View();
      }

      [Authorize(Policy = "CanGiveBonus")]
      public IActionResult GiveBonus()
      {
         return View();
      }

      public async Task<IActionResult> PayExpenses(Manager inputModel)
      {
         var result = await _authorizationService.AuthorizeAsync(User, inputModel, "HasExpenseCredit");
         if (!result.Succeeded)
            return Forbid(); 

         return View();
      }
   }
}