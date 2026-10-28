using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Dtos;
using tecBackend.Models;
using tecBackend.Models.DTO;
using tecBackend.Services;
using tecBackend.Utils;

namespace tecBackend.Controllers;

[Authorize(Roles = "SuperAdmin, Admin")]
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly SiteContext _context;
    private readonly IActivityLogService _activityLog;

    public AdminController(SiteContext context, IActivityLogService activityLog)
    {
        _context = context;
        _activityLog = activityLog;
    }

    private int? GetCurrentUserId()
    {
        var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.TryParse(idClaim, out var id) ? id : null;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _context
            .Users.Select(u => new
            {
                u.Id,
                Username = u.Login,
                Email = u.Mail,
                u.Role,
            })
            .ToListAsync();

        return Ok(users);
    }

    [HttpPut("users/{id}/role")]
    public async Task<IActionResult> UpdateUserRole(int id, [FromBody] UpdateRoleRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Role))
        {
            return BadRequest(new { message = "Роль не указана" });
        }

        var validRoles = new[] { "SuperAdmin", "Admin", "Worker", "Guest" };
        if (!validRoles.Contains(request.Role))
        {
            return BadRequest(new { message = "Недопустимая роль в системе" });
        }

        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound(new { message = "Пользователь не найден" });
        }

        var oldRole = user.Role;
        user.Role = request.Role;

        _activityLog.Log(
            "role_changed",
            $"Изменена роль пользователя {user.Login}",
            $"{oldRole ?? "—"} → {request.Role}",
            GetCurrentUserId()
        );

        await _context.SaveChangesAsync();

        return Ok(
            new { message = $"Роль пользователя {user.Login} успешно изменена на {request.Role}" }
        );
    }

    private bool IsAdmin => User.IsInRole("Admin") || User.IsInRole("SuperAdmin");

    // Общая проекция новости: Category отдаётся плоским объектом (без циклов).
    private static readonly System.Linq.Expressions.Expression<Func<Post, object>> PostProjection =
        p => new
        {
            p.Id,
            p.Title,
            p.Content,
            p.Summary,
            p.CreatedAt,
            p.UpdatedAt,
            p.CreatorName,
            p.CreatorDepartment,
            p.CategoryId,
            Category = new { p.Category.Id, p.Category.Name },
            p.IsPublished,
            p.ShowOnMain,
            p.Priority,
        };

    /// <summary>Все новости, включая черновики — только для админов (класс под [Authorize]).</summary>
    [HttpGet("posts")]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _context
            .Posts.OrderByDescending(p => p.CreatedAt)
            .Select(PostProjection)
            .ToListAsync();

        return Ok(posts);
    }

    [AllowAnonymous]
    [HttpGet("posts/{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        // Черновики видят только администраторы.
        var isAdmin = IsAdmin;

        var post = await _context
            .Posts.Where(p => p.Id == id && (p.IsPublished || isAdmin))
            .Select(PostProjection)
            .FirstOrDefaultAsync();

        if (post == null)
            return NotFound(new { message = "Пост не найден" });

        return Ok(post);
    }

    /// <summary>Публичная лента: только опубликованные, сначала по дате.</summary>
    [AllowAnonymous]
    [HttpGet("posts/public")]
    public async Task<IActionResult> GetPublicPosts()
    {
        var posts = await _context
            .Posts.Where(p => p.IsPublished)
            .OrderByDescending(p => p.CreatedAt)
            .Select(PostProjection)
            .ToListAsync();

        return Ok(posts);
    }

    /// <summary>Новости для главной: опубликованные + «показать на главной», по приоритету, затем по дате.</summary>
    [AllowAnonymous]
    [HttpGet("posts/featured")]
    public async Task<IActionResult> GetFeaturedPosts([FromQuery] int take = 5)
    {
        take = Math.Clamp(take, 1, 12);

        var posts = await _context
            .Posts.Where(p => p.IsPublished && p.ShowOnMain)
            .OrderByDescending(p => p.Priority)
            .ThenByDescending(p => p.CreatedAt)
            .Take(take)
            .Select(PostProjection)
            .ToListAsync();

        return Ok(posts);
    }

    [HttpPost("posts")]
    public async Task<IActionResult> CreatePost([FromBody] PostRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Content))
        {
            return BadRequest(new { message = "Заголовок и содержание обязательны" });
        }

        var userId = GetCurrentUserId();
        var creator =
            userId != null
                ? await _context
                    .Users.Include(u => u.Otdel)
                    .FirstOrDefaultAsync(u => u.Id == userId)
                : null;

        var creatorInfo = await CreatorInfoResolver.ResolveAsync(_context, creator);

        var post = new Post
        {
            Title = request.Title.Trim(),
            Content = request.Content,
            Summary = string.IsNullOrWhiteSpace(request.Summary) ? null : request.Summary.Trim(),
            CategoryId = request.CategoryId, // Присваиваем ID категории
            IsPublished = request.IsPublished,
            ShowOnMain = request.ShowOnMain,
            Priority = request.Priority,
            CreatedAt = BishkekClock.Now,
            CreatedByUserId = userId,
            CreatorName = creatorInfo.Name,
            CreatorDepartment = creatorInfo.Department,
        };

        _context.Posts.Add(post);

        _activityLog.Log(
            "post_created",
            request.IsPublished ? "Опубликована новость" : "Создан черновик новости",
            post.Title,
            userId
        );

        await _context.SaveChangesAsync();

        return Ok(new { message = "Пост успешно создан", id = post.Id });
    }

    [HttpPut("posts/{id}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] PostRequest request)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return NotFound(new { message = "Пост не найден" });

        post.Title = request.Title?.Trim();
        post.Content = request.Content;
        post.Summary = string.IsNullOrWhiteSpace(request.Summary) ? null : request.Summary.Trim();
        post.CategoryId = request.CategoryId;
        post.IsPublished = request.IsPublished;
        post.ShowOnMain = request.ShowOnMain;
        post.Priority = request.Priority;
        post.UpdatedAt = BishkekClock.Now;

        _activityLog.Log("post_updated", "Новость обновлена", post.Title, GetCurrentUserId());

        await _context.SaveChangesAsync();
        return Ok(new { message = "Пост успешно обновлен" });
    }

    /// <summary>Быстрое переключение «опубликовано / на главной / приоритет» из таблицы.</summary>
    [HttpPatch("posts/{id}/flags")]
    public async Task<IActionResult> UpdatePostFlags(int id, [FromBody] PostFlagsRequest request)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return NotFound(new { message = "Пост не найден" });

        if (request.IsPublished.HasValue)
            post.IsPublished = request.IsPublished.Value;
        if (request.ShowOnMain.HasValue)
            post.ShowOnMain = request.ShowOnMain.Value;
        if (request.Priority.HasValue)
            post.Priority = request.Priority.Value;

        post.UpdatedAt = BishkekClock.Now;

        _activityLog.Log("post_updated", "Параметры новости изменены", post.Title, GetCurrentUserId());

        await _context.SaveChangesAsync();
        return Ok(new { message = "Параметры обновлены" });
    }

    [HttpDelete("posts/{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return NotFound(new { message = "Пост не найден" });

        _context.Posts.Remove(post);

        _activityLog.Log("post_deleted", "Новость удалена", post.Title, GetCurrentUserId());

        await _context.SaveChangesAsync();

        return Ok(new { message = "Пост удален" });
    }
}
