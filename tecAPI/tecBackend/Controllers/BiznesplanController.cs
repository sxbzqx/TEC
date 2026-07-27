using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Models;

namespace tecBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BiznesplanController : ControllerBase
{
    private readonly SiteContext _context;

    public BiznesplanController(SiteContext context)
    {
        _context = context;
    }


    
    
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BiznesplanVariant>>> GetBP()
    {
        return await _context.BiznesplanVariants.ToListAsync();
    }

    
    
    
    
    [HttpGet("oks")]
    public async Task<ActionResult<IEnumerable<BiznesplanoksVariant>>> GetBPoks()
    {
        return await _context.BiznesplanoksVariants.ToListAsync();
    }
}