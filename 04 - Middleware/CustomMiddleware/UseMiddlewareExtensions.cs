using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CustomMiddleware
{
  public static class UseMiddlewareExtensions
  {
    public static IApplicationBuilder UseMiddleware1(this IApplicationBuilder app)
    {
      return app.Use(async (context, next) =>
      {
        await context.Response.WriteAsync("<br/> Middleware 1 - I am an USE Extension class<br/>");
        await next();
      });
    }

    public static IApplicationBuilder UseMiddleware2InClass(this IApplicationBuilder app)
    {
      return app.UseMiddleware<Middleware2>();
    }
  }

  public class Middleware2
  {
    private readonly RequestDelegate _next;

    public Middleware2(RequestDelegate next)
    {
      this._next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      await context.Response.WriteAsync("Middleware 2 - I am a Custom Middleware CLass<br/>");
      await this._next(context);
    }
  }
}
