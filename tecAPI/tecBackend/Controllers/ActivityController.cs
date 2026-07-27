using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Models;

namespace tecBackend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly SiteContext _context;

    public ActivityController(SiteContext context)
    {
        _context = context;
    }


    /// <summary>
    /// Активности: создание новостей и т.д. 
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetRecent([FromQuery] int take = 10)
    {
        take = Math.Clamp(take, 1, 50);

        var items = await _context
            .ActivityLogs.OrderByDescending(a => a.CreatedAt)
            .Take(take)
            .Select(a => new
            {
                id = a.Id,
                action = a.Action,
                title = a.Title,
                subtitle = a.Subtitle,
                createdAt = a.CreatedAt.Kind == DateTimeKind.Unspecified
                    ? DateTime.SpecifyKind(a.CreatedAt, DateTimeKind.Utc)
                    : a.CreatedAt,
            })
            .ToListAsync();

        return Ok(items);
    }
}
