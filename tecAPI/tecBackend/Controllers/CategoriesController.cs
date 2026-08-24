using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Models;

namespace tecBackend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly SiteContext _context;

    public CategoriesController(SiteContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Категории новостей. 
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _context.Categories.ToListAsync();
        return Ok(categories);
    }
}