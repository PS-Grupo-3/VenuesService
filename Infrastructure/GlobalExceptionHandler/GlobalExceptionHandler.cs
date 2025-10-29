using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Exceptions;

namespace VenueService.Infraestructure.GlobalExceptionHandler;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext ctx,
        Exception ex,
        CancellationToken token)
    {
        var status = ex switch
        {
            NotFoundException => HttpStatusCode.NotFound,
            ValidationException => HttpStatusCode.BadRequest,
            UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            BadHttpRequestException => HttpStatusCode.BadRequest,
            ArgumentException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);

        var problem = new ProblemDetails
        {
            Status = (int)status,
            Title = ex.GetType().Name,
            Detail = ex.Message
        };
        problem.Extensions["traceId"] = ctx.TraceIdentifier;

        ctx.Response.StatusCode = problem.Status!.Value;
        ctx.Response.ContentType = "application/problem+json";

        await ctx.Response.WriteAsJsonAsync(problem, cancellationToken: token);

        return true;
    }
}
