using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BasicRouting
{
  public class Startup
  {// This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
           name: "gotoOne",
           pattern: "one",
           defaults: new { controller = "Home", action = "ViewOne" });

        endpoints.MapControllerRoute(
           name: "gotoTwo",
           pattern: "two/{id?}",
           defaults: new { controller = "Home", action = "ViewTwo" });

        endpoints.MapControllerRoute(
           name: "default",
           pattern: "{controller=Home}/{action=index}/{id?}");
      });

      //app.UseEndpoints(endpoints =>
      //{
      //  // Route template with default values and optional parameters
      //  endpoints.MapControllerRoute(
      //     name: "gotoOne",
      //     pattern: "{controller=Home}/{action=ViewOne}/{id?}");

      //  // Route template with default value, parameter constrainst
      //  endpoints.MapControllerRoute(
      //     name: "gotoTwo",
      //     pattern: "{controller}/{action}/{id?}");

      //  // Route template with no default values or parameters
      //  endpoints.MapControllerRoute(
      //     name: "default",
      //     pattern: "{controller}/{action}/{id?}");
      //});
    }
  }
}
