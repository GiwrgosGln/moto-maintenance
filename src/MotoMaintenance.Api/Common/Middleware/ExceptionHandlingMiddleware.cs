using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotoMaintenance.Api.Common.Exceptions;

namespace MotoMaintenance.Api.Common.Middleware;

public sealed class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task Invoke(HttpContext ctx)
    {
        try
        {
            await next(ctx);
        }
        catch (AppException ex)
        {
            await WriteProblem(ctx, ex.StatusCode, ex.Title, ex.Message);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

            ctx.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await ctx.Response.WriteAsJsonAsync(new ValidationProblemDetails(errors)
            {
                Status = (int)HttpStatusCode.BadRequest,
                Title = "Validation failed",
                Instance = ctx.Request.Path
            });
        }
        catch (BadHttpRequestException ex)
        {
            await WriteProblem(ctx, (int)HttpStatusCode.BadRequest,
                "Bad Request", ExtractBindingDetail(ex));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception on {Path}", ctx.Request.Path);
            await WriteProblem(ctx, (int)HttpStatusCode.InternalServerError,
                "Internal Server Error", "An unexpected error occurred.");
        }
    }

    private static async Task WriteProblem(HttpContext ctx, int status, string title, string detail)
    {
        ctx.Response.StatusCode = status;
        await ctx.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = status, Title = title, Detail = detail, Instance = ctx.Request.Path
        });
    }

    private static string ExtractBindingDetail(BadHttpRequestException ex)
    {
        var msg = ex.Message;

        const string jsonMarker = "as JSON";
        var jsonIdx = msg.IndexOf(jsonMarker, StringComparison.Ordinal);
        if (jsonIdx >= 0)
        {
            const string paramMarker = "parameter \"";
            var paramStart = msg.IndexOf(paramMarker, StringComparison.Ordinal);
            if (paramStart >= 0)
            {
                paramStart += paramMarker.Length;
                var paramEnd = msg.IndexOf('"', paramStart);
                if (paramEnd > paramStart)
                {
                    var paramName = msg[paramStart..paramEnd];
                    return $"The request body is not valid JSON or is missing required values for '{paramName}'.";
                }
            }

            var detail = msg[(jsonIdx + jsonMarker.Length)..].TrimStart(' ', '.', ':');
            return string.IsNullOrEmpty(detail) ? msg : detail;
        }

        return msg;
    }
}