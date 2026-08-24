using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Models;

namespace tecBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OtdelsController : ControllerBase
{
    private readonly SiteContext _context;

    public OtdelsController(SiteContext context)
    {
        _context = context;
    }

    
    
    
    [HttpGet]
    
    public async Task<ActionResult<IEnumerable<Otdel>>> GetOtdels()
    {
        return await _context.Otdels.ToListAsync();
    }
}
