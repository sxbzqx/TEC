using Microsoft.EntityFrameworkCore;
using tecBackend.Models;

namespace tecBackend.Extensions;

public static class WebApplicationExtensions
{
    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<SiteContext>();
        await db.Database.MigrateAsync();
    }
}