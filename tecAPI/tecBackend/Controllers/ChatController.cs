using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Models;

namespace tecBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
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
    public async Task<ActionResult<Chat>> PostChat(Chat chat)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        
        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();

        
        
        return CreatedAtAction(nameof(GetChat), new { id = chat.Id }, chat);
    }
}
