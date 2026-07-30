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

    /// <summary>
    /// Полный журнал действий с пагинацией и фильтрами — только для SuperAdmin.
    /// </summary>
    [HttpGet("log")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> GetLog(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25,
        [FromQuery] string? action = null,
        [FromQuery] int? actorUserId = null,
        [FromQuery] DateTime? from = null,
        [FromQuery] DateTime? to = null
    )
    {
        page = Math.Max(page, 1);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var query = _context.ActivityLogs.AsQueryable();

        if (!string.IsNullOrWhiteSpace(action))
        {
            query = query.Where(a => a.Action == action);
        }

        if (actorUserId.HasValue)
        {
            query = query.Where(a => a.ActorUserId == actorUserId);
        }

        if (from.HasValue)
        {
            query = query.Where(a => a.CreatedAt >= from.Value);
        }

        if (to.HasValue)
        {
            query = query.Where(a => a.CreatedAt <= to.Value);
        }

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(a => a.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .GroupJoin(
                _context.Users,
                a => a.ActorUserId,
                u => u.Id,
                (a, users) => new { a, users }
            )
            .SelectMany(
                x => x.users.DefaultIfEmpty(),
                (x, u) => new
                {
                    id = x.a.Id,
                    action = x.a.Action,
                    title = x.a.Title,
                    subtitle = x.a.Subtitle,
                    actorUserId = x.a.ActorUserId,
                    actorLogin = u != null ? u.Login : null,
                    createdAt = x.a.CreatedAt.Kind == DateTimeKind.Unspecified
                        ? DateTime.SpecifyKind(x.a.CreatedAt, DateTimeKind.Utc)
                        : x.a.CreatedAt,
                }
            )
            .ToListAsync();

        return Ok(
            new
            {
                total,
                page,
                pageSize,
                items,
            }
        );
    }

    /// <summary>
    /// Список уникальных типов событий — для выпадающего фильтра на фронте.
    /// </summary>
    [HttpGet("actions")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> GetActions()
    {
        var actions = await _context
            .ActivityLogs.Select(a => a.Action)
            .Distinct()
            .OrderBy(a => a)
            .ToListAsync();

        return Ok(actions);
    }
}