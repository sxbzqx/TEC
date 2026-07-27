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

    [AllowAnonymous]
    [HttpGet("posts")]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _context
            .Posts.Include(p => p.Category)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();

        return Ok(posts);
    }

    [AllowAnonymous]
    [HttpGet("posts/{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var post = await _context
            .Posts.Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (post == null)
            return NotFound(new { message = "Пост не найден" });

        return Ok(post);
    }

    [AllowAnonymous]
    [HttpGet("posts/public")]
    public async Task<IActionResult> GetPublicPosts()
    {
        var posts = await _context
            .Posts.OrderByDescending(p => p.CreatedAt)
            .Select(p => new
            {
                p.Id,
                p.CreatorName,
                p.Title,
                p.Content,
                p.CreatedAt,
            })
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
            Title = request.Title,
            Content = request.Content,
            CategoryId = request.CategoryId, // Присваиваем ID категории
            CreatedAt = BishkekClock.Now,
            CreatedByUserId = userId,
            CreatorName = creatorInfo.Name,
            CreatorDepartment = creatorInfo.Department,
        };

        _context.Posts.Add(post);

        _activityLog.Log("post_created", "Опубликована новость", post.Title, userId);

        await _context.SaveChangesAsync();

        return Ok(new { message = "Пост успешно создан", id = post.Id });
    }

    [HttpPut("posts/{id}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] PostRequest request)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return NotFound(new { message = "Пост не найден" });

        post.Title = request.Title;
        post.Content = request.Content;
        post.CategoryId = request.CategoryId;

        _activityLog.Log("post_updated", "Новость обновлена", post.Title, GetCurrentUserId());

        await _context.SaveChangesAsync();
        return Ok(new { message = "Пост успешно обновлен" });
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
