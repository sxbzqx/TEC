using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Models;

namespace tecBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResourcesController : ControllerBase
{
    private readonly SiteContext _context;

    public ResourcesController(SiteContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Список типов ресурсов (видов заявок) для выпадающего списка на форме создания заявки.
    /// </summary>
    [HttpGet]
    [Authorize(Roles = "Admin,SuperAdmin, Worker")]
    public async Task<ActionResult<IEnumerable<Resource>>> GetResources()
    {
        return await _context.Resources.ToListAsync();
    }
}
