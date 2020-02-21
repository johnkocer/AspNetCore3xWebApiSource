using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MiddlewareBasic
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      //if (env.IsDevelopment())
      //{
      //  app.UseDeveloperExceptionPage();
      //}
      app.Use(async (context, next) =>
      {
        await context.Response.WriteAsync("<br/>Middleware 1-------------------><br/>");
        // Calls next middleware in pipeline
        await next.Invoke();
      });
      app.Use(async (context, next) =>
      {
        await context.Response.WriteAsync("Middleware 2-------------------><br/>");
        // Calls next middleware in pipeline
        await next.Invoke();
      });
      app.Use(async (context, next) =>
      {
        await context.Response.WriteAsync("Middleware 3-------------------><br/>");
        // Calls next middleware in pipeline
        await next.Invoke();
      });
      app.Use(async (context, next) =>
      {
        await context.Response.WriteAsync("Middleware 4-------------------><br/>");
        // Calls next middleware in pipeline
        //await next.Invoke();
      });
      //app.UseRouting();

      //app.UseEndpoints(endpoints =>
      //{
      //  endpoints.MapGet("/", async context =>
      //        {
      //      await context.Response.WriteAsync("Hello World!");
      //    });
      //});
    }
  }
}
