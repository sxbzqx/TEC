using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Models;

namespace tecBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticController : ControllerBase
{
    private readonly SiteContext _context;

    public StatisticController(SiteContext context)
    {
        _context = context;
    }

    
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatisticYear>>> GetStatistic()
    {
        return await _context.StatisticYears.ToListAsync();
    }
}
