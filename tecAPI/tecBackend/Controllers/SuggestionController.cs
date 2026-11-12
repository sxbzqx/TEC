using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Dtos;
using tecBackend.Extensions;
using tecBackend.Models;
using tecBackend.Utils;

namespace tecBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuggestionsController(SiteContext context) : ControllerBase
{
    /// <summary>Отправить предложение. Доступно сотрудникам (Worker, Admin, SuperAdmin).</summary>
    [HttpPost]
    [Authorize(Roles = "Admin,SuperAdmin,Worker")]
    public async Task<ActionResult<SuggestionDto>> Create([FromBody] CreateSuggestionRequest request)
    {
        if (User.GetUserId() is not int userId)
            return Unauthorized();

        var text = request.Text?.Trim();
        if (string.IsNullOrEmpty(text))
            return BadRequest(new { message = "Опишите ваше предложение" });

        var comment = request.Comment?.Trim();

        var suggestion = new Suggestion
        {
            UserId = userId,
            Text = text,
            Comment = string.IsNullOrEmpty(comment) ? null : comment,
            CreatedAt = BishkekClock.Now,
        };

        context.Suggestions.Add(suggestion);
        await context.SaveChangesAsync();

        return Ok(ToDto(suggestion));
    }

    /// <summary>Мои предложения — только те, что оставил текущий пользователь.</summary>
    [HttpGet("my")]
    [Authorize(Roles = "Admin,SuperAdmin,Worker")]
    public async Task<ActionResult<IEnumerable<SuggestionDto>>> GetMy()
    {
        if (User.GetUserId() is not int userId)
            return Unauthorized();

        var items = await context
            .Suggestions.Where(s => s.UserId == userId)
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync();

        return Ok(items.Select(ToDto));
    }

    /// <summary>Все предложения с указанием автора — для раздела администрирования.</summary>
    [HttpGet]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public async Task<ActionResult<IEnumerable<AdminSuggestionDto>>> GetAll()
    {
        var items = await context.Suggestions.OrderByDescending(s => s.CreatedAt).ToListAsync();

        // Имена авторов предложений и администраторов, оставивших комментарии.
        var authors = await CreatorInfoResolver.ResolveManyAsync(
            context,
            items
                .Select(s => s.UserId)
                .Concat(items.Where(s => s.AdminCommentByUserId != null).Select(s => s.AdminCommentByUserId!.Value))
        );

        var authorIds = items.Select(s => s.UserId).Distinct().ToList();
        var logins = (await context.Users.ToListAsync())
            .Where(u => authorIds.Contains(u.Id))
            .ToDictionary(u => u.Id, u => u.Login);

        var result = items.Select(s =>
        {
            var author =
                authors.GetValueOrDefault(s.UserId)
                ?? new CreatorInfoResolver.CreatorInfo("Неизвестно", null);

            return new AdminSuggestionDto
            {
                Id = s.Id,
                Text = s.Text,
                Comment = s.Comment,
                CreatedAt = s.CreatedAt,
                UserId = s.UserId,
                UserName = author.Name,
                UserLogin = logins.GetValueOrDefault(s.UserId, ""),
                UserDepartment = author.Department,
                AdminComment = s.AdminComment,
                AdminCommentAt = s.AdminCommentAt,
                AdminCommentBy =
                    s.AdminCommentByUserId is int adminId && authors.TryGetValue(adminId, out var admin)
                        ? admin.Name
                        : null,
            };
        });

        return Ok(result);
    }

    /// <summary>Оставить, изменить или (пустым значением) удалить комментарий администратора.</summary>
    [HttpPut("{id:int}/comment")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public async Task<ActionResult<SuggestionDto>> SetAdminComment(
        int id,
        [FromBody] UpdateSuggestionCommentRequest request
    )
    {
        if (User.GetUserId() is not int adminId)
            return Unauthorized();

        var suggestion = await context.Suggestions.FindAsync(id);
        if (suggestion == null)
            return NotFound();

        var comment = request.Comment?.Trim();
        if (string.IsNullOrEmpty(comment))
        {
            suggestion.AdminComment = null;
            suggestion.AdminCommentAt = null;
            suggestion.AdminCommentByUserId = null;
        }
        else
        {
            suggestion.AdminComment = comment;
            suggestion.AdminCommentAt = BishkekClock.Now;
            suggestion.AdminCommentByUserId = adminId;
        }

        await context.SaveChangesAsync();
        return Ok(ToDto(suggestion));
    }

    private static SuggestionDto ToDto(Suggestion s) =>
        new()
        {
            Id = s.Id,
            Text = s.Text,
            Comment = s.Comment,
            CreatedAt = s.CreatedAt,
            AdminComment = s.AdminComment,
            AdminCommentAt = s.AdminCommentAt,
        };
}