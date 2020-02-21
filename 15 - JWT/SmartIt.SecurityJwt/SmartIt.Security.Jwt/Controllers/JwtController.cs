using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartIt.Security.Jwt.Controllers
{
    public class JwtController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}