using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ParkingAPI.Middleware;

public class ProblemDetailsExceptionHandler(
    ProblemDetailsFactory factory,
    ILogger<ProblemDetailsExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        if (exception is GateNotFoundException)
        {
            logger.Log(LogLevel.Information, $"Exception '{exception.Message} handled'");
            var problem = factory.CreateProblemDetails(
                httpContext,
                StatusCodes.Status404NotFound,
                "Gate not found",
                detail: exception.Message
            );
            
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);
            
            return true;
        }
        return false;
    }
}