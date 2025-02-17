using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WorkOS.API.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ProblemDetails problemDetails;
            switch(exception)
            {
                case ArgumentNullException:
                    problemDetails = new ProblemDetails
                    {
                        Title = "Descrição da exception",
                        Status = StatusCodes.Status400BadRequest,
                        Detail = exception.Message
                    };
                    break;
                default:
                    return ValueTask.FromResult(false);
            }

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            httpContext.Response.WriteAsJsonAsync(problemDetails);
            return ValueTask.FromResult(true);
        }
    }
}
