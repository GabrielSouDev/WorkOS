using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorkOS.Data.Exceptions;

namespace WorkOS.API.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public readonly RequestDelegate _next;
    public GlobalExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
             await TryHandleAsync(httpContext, exception, CancellationToken.None);
        }
    }
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ProblemDetails problemDetails;
        switch(exception)
        {
            case EntityNotFoundException:
                problemDetails = new ProblemDetails
                {
                    Title = "Entity Item não encontrado",
                    Status = StatusCodes.Status404NotFound,
                    Detail = exception.Message
                };
                break;

            case BadHttpRequestException:
                problemDetails = new ProblemDetails
                {
                    Title = "Problema durante requisição",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = exception.Message
                };
                break;

            case NotImplementedException:
                problemDetails = new ProblemDetails
                {
                    Title = "Endpoint em fase de implementação",
                    Status = StatusCodes.Status405MethodNotAllowed,
                    Detail = exception.Message
                };
                break;

            default:
                problemDetails = new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = exception.Message
                };
                break;
        }

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        httpContext.Response.ContentType = "application/problem+json";
        httpContext.Response.WriteAsJsonAsync(problemDetails).GetAwaiter().GetResult();
        return ValueTask.FromResult(true);
    }
}
