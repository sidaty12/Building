using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace API.Middlewares
{
  public class ExceptionMiddleware
  {
    private readonly IHostEnvironment env;
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionMiddleware> logger;

    public ExceptionMiddleware(RequestDelegate next,
      ILogger<ExceptionMiddleware> logger,
      IHostEnvironment env)
    {
      this.env = env;
      this.next = next;
      this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
      {
        await next(context);
      }

      catch (Exception ex)
      {
        ApiError response;
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        string message;
        var exeptionType = ex.GetType();

        if(exeptionType == typeof(UnauthorizedAccessException))
        {
          statusCode = HttpStatusCode.Forbidden;
          message = "You are not authorized";
        }
        else
        {
          statusCode = HttpStatusCode.InternalServerError;
          message = "Some unknown error ocured";
        }
        if (env.IsDevelopment())
        {
          response = new ApiError((int)statusCode,ex.Message,ex.StackTrace.ToString());
        }
        else
        {
          response = new ApiError((int)statusCode, message);
        }
        logger.LogError(ex, ex.Message);
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(response.ToString());

      }
    }
  }
}
