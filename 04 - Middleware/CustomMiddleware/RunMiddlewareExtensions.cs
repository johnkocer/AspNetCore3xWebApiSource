using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CustomMiddleware
{
  public static class RunMiddlewareExtensions
  {
    public static void RunMiddleware3(this IApplicationBuilder app)
    {
      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Middleware 3 - I am a RUN Extension class<br/>");
      });
    }
  }
}