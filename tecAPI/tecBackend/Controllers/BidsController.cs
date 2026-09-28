using System.Runtime.CompilerServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Dtos;
using tecBackend.Models;
using tecBackend.Utils;


[Route("api/[controller]")]
[ApiController]
public class BidsController : ControllerBase
{
    private readonly SiteContext _context;

    public BidsController(SiteContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Все заявки. 
    /// </summary>
    [HttpGet]
    [Authorize(Roles = "Admin,SuperAdmin,Worker")]
    public async Task<ActionResult<IEnumerable<Document>>> GetDocuments()
    {
        return await _context.Documents.ToListAsync();
    }

    /// <summary>
    /// Создание новой заявки.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Admin,SuperAdmin,Worker")]
    public async Task<ActionResult<Document>> CreateDocument([FromBody] CreateDocumentRequest request)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
        if (string.IsNullOrEmpty(userIdClaim))
            return Unauthorized();

        var resource = await _context.Resources.FirstOrDefaultAsync(r => r.Id == request.IdResource);
        if (resource == null)
            return BadRequest(new { message = "Выбранный ресурс не найден" });

        var document = new Document
        {
            IdPerUser = int.Parse(userIdClaim),
            IdUser = userIdClaim,
            IdResource = request.IdResource,
            Amount = request.Amount,
            DateFirst = BishkekClock.Now,
            UserReshenie = "",
            CommentReshenie = "",
            Action = 0,
            IdReceiver = resource.IdOtd,
            Archive = 0,
            Comment = request.Comment,
            Made = 0,
        };

        _context.Documents.Add(document);
        await _context.SaveChangesAsync();

        return Ok(document);
    }

    /// <summary>
    /// Заявки, адресованные отделу ОКиТ.
    /// </summary>
    [HttpGet("incoming")]
    [Authorize(Roles = "Admin,SuperAdmin,Worker")]
    public async Task<ActionResult<IEnumerable<DocumentIncomingDto>>> GetIncoming()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
        if (string.IsNullOrEmpty(userIdClaim))
            return Unauthorized();

        var user = await _context.Users
            .Include(u => u.Otdel)
            .FirstOrDefaultAsync(u => u.Id == int.Parse(userIdClaim));

        if (user?.Otdel == null)
            return Ok(Array.Empty<DocumentIncomingDto>());

        var otdelCode = user.Otdel.Id.ToString();

        var documents = await _context.Documents
            .Where(d => d.IdReceiver == otdelCode && d.Archive == 0)
            .OrderByDescending(d => d.DateFirst)
            .ToListAsync();

        var resourceIds = documents.Select(d => d.IdResource).Distinct().ToList();
        var resourceNames = new Dictionary<int, string>();
        if (resourceIds.Count > 0)
        {
            var allResources = await _context.Resources.ToListAsync();
            resourceNames = allResources
                .Where(r => resourceIds.Contains(r.Id))
                .ToDictionary(r => (int)r.Id, r => r.Name);
        }

        var creatorInfoById = await CreatorInfoResolver.ResolveManyAsync(
            _context,
            documents.Select(d => d.IdPerUser)
        );

        var result = documents.Select(d =>
        {
            var creatorInfo = creatorInfoById.GetValueOrDefault(d.IdPerUser)
                ?? new CreatorInfoResolver.CreatorInfo("Неизвестно", null);

            return new DocumentIncomingDto
            {
                Id = d.Id,
                DateFirst = d.DateFirst,
                IdResource = d.IdResource,
                ResourceName = resourceNames.GetValueOrDefault(d.IdResource, ""),
                CreatorName = creatorInfo.Name,
                CreatorDepartment = creatorInfo.Department,
                Amount = d.Amount,
                Comment = d.Comment,
                Action = d.Action,
                Made = d.Made,
                DateReshenie = d.DateReshenie,
                CommentReshenie = d.CommentReshenie,
                DateVyp = d.DateVyp,
            };
        });

        return Ok(result);
    }

    /// <summary>
    /// Детали одной заявки — доступна только сотруднику отдела ОКиТ.
    /// </summary>
    [HttpGet("{id:int}")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public async Task<ActionResult<DocumentIncomingDto>> GetDocumentById(int id)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
        if (string.IsNullOrEmpty(userIdClaim))
            return Unauthorized();

        var user = await _context.Users
            .Include(u => u.Otdel)
            .FirstOrDefaultAsync(u => u.Id == int.Parse(userIdClaim));

        var document = await _context.Documents.FindAsync(id);
        if (document == null)
            return NotFound();

        if (user?.Otdel == null || document.IdReceiver != user.Otdel.Id.ToString())
            return Forbid();

        var resource = await _context.Resources.FirstOrDefaultAsync(r => r.Id == document.IdResource);

        var creatorUser = await _context.Users
            .Include(u => u.Otdel)
            .FirstOrDefaultAsync(u => u.Id == document.IdPerUser);
        var creatorInfo = await CreatorInfoResolver.ResolveAsync(_context, creatorUser);

        return Ok(new DocumentIncomingDto
        {
            Id = document.Id,
            DateFirst = document.DateFirst,
            IdResource = document.IdResource,
            ResourceName = resource?.Name ?? "",
            CreatorName = creatorInfo.Name,
            CreatorDepartment = creatorInfo.Department,
            Amount = document.Amount,
            Comment = document.Comment,
            Action = document.Action,
            Made = document.Made,
            DateReshenie = document.DateReshenie,
            CommentReshenie = document.CommentReshenie,
            DateVyp = document.DateVyp,
        });
    }
    
    /// <summary>
    /// Решение по заявке: разрешить (1), отклонить (2) или отложить (3).
    /// Разрешено принимать решение только для новой заявки (0) или ранее
    /// отложенной (3) — из "отложено" можно позже перейти в любой статус.
    /// </summary>
    [HttpPut("{id:int}/decision")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public async Task<IActionResult> DecideDocument(int id, [FromBody] DecideDocumentRequest request)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
        if (string.IsNullOrEmpty(userIdClaim))
            return Unauthorized();

        var document = await _context.Documents.FindAsync(id);
        if (document == null)
            return NotFound();

        if (document.Action != 0 && document.Action != 3)
            return BadRequest(new { message = "Решение по этой заявке уже принято" });

        document.Action = request.Action;
        document.UserReshenie = userIdClaim;
        document.DateReshenie = BishkekClock.Now;
        document.CommentReshenie = request.Comment ?? "";

        await _context.SaveChangesAsync();
        return Ok(document);
    }

    /// <summary>
    /// Отметить разрешённую заявку как выполненную.
    /// </summary>
    [HttpPut("{id:int}/complete")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public async Task<IActionResult> CompleteDocument(int id)
    {
        var document = await _context.Documents.FindAsync(id);
        if (document == null)
            return NotFound();

        if (document.Action != 1)
            return BadRequest(new { message = "Заявка ещё не разрешена" });

        if (document.Made == 1)
            return BadRequest(new { message = "Заявка уже выполнена" });

        document.Made = 1;
        document.DateVyp = BishkekClock.Now;

        await _context.SaveChangesAsync();
        return Ok(document);
    }
}