using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace SmartIt.Security.Jwt
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();
      services.AddControllers();
      services.AddRazorPages(); // Don't need for Web API
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddJwtBearer(options =>
         {
            //options.RequireHttpsMetadata = false;
            //options.SaveToken = true;

            options.TokenValidationParameters = new TokenValidationParameters()
           {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,

             ValidIssuer = "SmartIt.Security.Jwt",
             ValidAudience = "SmartIt.Security.Jwt",
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SmartIt-secret-key"))
           };

         });

      services.AddAuthorization(options =>
      {
        options.AddPolicy("Member",
            policy => policy.RequireClaim("MemberId"));
      });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseDeveloperExceptionPage();
      app.UseStaticFiles();
      app.UseRouting();

      // global cors policy
      app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages(); // Don't need for Web API 
      });
    }
  }
}
