using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HtmlPageStartUp
{
   [Route("api/[controller]")]
   public class CustomerController : Controller
   {
      EmailList emailList = new EmailList();

      [Route("~/api/GetAll")]
      [HttpGet]
      public IEnumerable<string> GetAll()
      {
         return EmailList.Items;
      }

      [Route("~/api/EmailIsExist")]
      [HttpPost]
      public bool EmailIsExist([FromBody]string email)
      {
         return EmailList.Items.Contains(email);
      }
   }

   public class EmailList
   {
      public static List<string> Items = new List<string>();
      // static constructor executes only once
      static EmailList() // static constructor 
      {
         EmailList.Items.Add("amazon@amazon.com");
         EmailList.Items.Add("intel@intel.com");
         EmailList.Items.Add("amd@amd.com");
         EmailList.Items.Add("john@gmail.com");
      }
   }
}
