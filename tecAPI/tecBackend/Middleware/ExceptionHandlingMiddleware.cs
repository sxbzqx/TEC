using System.Text.Json;

namespace tecBackend.Middleware;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger,
    IHostEnvironment env)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
        {
            // Клиент оборвал запрос — не ошибка
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Необработанное исключение: {Method} {Path}",
                context.Request.Method, context.Request.Path);

            if (context.Response.HasStarted) throw;

            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                status = 500,
                title = "Внутренняя ошибка сервера",
                detail = env.IsDevelopment() ? ex.Message : null,
                traceId = context.TraceIdentifier,
            }));
        }
    }
}