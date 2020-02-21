using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SmartIt.Security.Cors
{
  // NOTE Use one Startup one at a time. There are multiple Startup for a difrerent COSR setup.
  // Enabling CORS basic
  public class Startup
  {

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(); // 1

      services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseCors(builder => builder.WithOrigins("http://localhost:44369").SetIsOriginAllowed((host) => true)); // 1

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }

  // Enabling CORS with a policy
  public class StartupP
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("SmartIt",
            builder => builder.WithOrigins("http://localhost:44369")
            .SetIsOriginAllowed((host) => true));
      });
      services.AddControllers();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      //global cors policy
      app.UseCors(x => x
          .WithOrigins("SmartIt")
          .AllowAnyMethod()
          .AllowAnyHeader());

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
  // Enabling CORS globaly
  public class StartupG
  {

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();
      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      //global cors policy
      app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
  // Enabling CORS with MVC
  public class StartupM
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("SmartIt",
            builder => builder.WithOrigins("http://localhost:44369")
            .SetIsOriginAllowed((host) => true));
      });
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
      app.UseCors("SmartIt");

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
