using DotNetEnv;
using tecBackend.Extensions;
using tecBackend.Middleware;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
builder.Configuration.AddEnvironmentVariables();

builder.Services
    .AddAppForwardedHeaders(builder.Configuration)
    .AddAppCors()
    .AddAppControllers()
    .AddAppDatabase(builder.Configuration)
    .AddAppSwagger()
    .AddAppServices()
    .AddAppJwtAuth(builder.Configuration)
    .AddAppRateLimiting();

var app = builder.Build();

app.UseForwardedHeaders();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseAppSwagger();
}

await app.ApplyMigrationsAsync();

app.UseRouting();
app.UseCors(CorsExtensions.PolicyName);
app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();