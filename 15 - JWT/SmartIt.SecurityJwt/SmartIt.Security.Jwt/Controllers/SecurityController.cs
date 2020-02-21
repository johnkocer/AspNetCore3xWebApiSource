using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SmartIt.Security.Jwt.Models.Security;

namespace SmartIt.Security.Jwt.Controllers
{
  [Produces("application/json")]
  [Route("Security")]
  [ApiController]
  [AllowAnonymous]
  public class SecurityController : ControllerBase
  {
    [HttpPost]
    public IActionResult GenerateToken([FromBody]LoginInputModel inputModel)
    {

      if (inputModel.UserName != "bob" && inputModel.Password != "Password!")
        return Unauthorized();

      var claims = new[]
              {
              new Claim(JwtRegisteredClaimNames.Sub, "bob"),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              new Claim("MemberId","100")
         };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SmartIt-secret-key"));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken("SmartIt.Security.Jwt",
        "SmartIt.Security.Jwt",
        claims,
        expires: DateTime.Now.AddDays(1),
        signingCredentials: creds);

      return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

    }
  }
}