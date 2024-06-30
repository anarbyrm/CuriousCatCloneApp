using CuriousCatClone.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CuriousCatClone.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseAppException exc)
            {
                // log error
                var statusCode = StatusCodes.Status400BadRequest;

                var problemDetails = new ProblemDetails()
                {
                    Status = statusCode,
                    Title = "Application Error"
                };

                List<string> errorDetails = new();

                foreach (var value in exc.errors)
                    errorDetails.Add(value);

                problemDetails.Extensions["errors"] = errorDetails;
                problemDetails.Detail = exc.Message;

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
            catch(Exception exc)
            {
                // log exception
                var statusCode = StatusCodes.Status500InternalServerError;

                var problemDetails = new ProblemDetails()
                {
                    Status = statusCode,
                    Title = "Server Error"
                };

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
