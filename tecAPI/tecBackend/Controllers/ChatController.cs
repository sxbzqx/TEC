using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Dtos;
using tecBackend.Models;
using tecBackend.Utils;

namespace tecBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "SuperAdmin,Admin,Worker")]
public class ChatController : ControllerBase
{
    private readonly SiteContext _context;

    public ChatController(SiteContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Chat>>> GetChat()
    {
        return await _context.Chats.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Chat>> PostChat([FromBody] CreateChatMessageRequest request)
    {
        if (!ModelState.IsValid || string.IsNullOrWhiteSpace(request.Message))
        {
            return BadRequest(ModelState);
        }

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
        if (string.IsNullOrEmpty(userIdClaim))
        {
            return Unauthorized();
        }

        var chat = new Chat
        {
            User = int.Parse(userIdClaim),
            Message = request.Message,
            Date = BishkekClock.Now,
        };

        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetChat), new { id = chat.Id }, chat);
    }
}
