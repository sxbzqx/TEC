using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tecBackend.Models;
using tecBackend.Services;

namespace tecBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OfficeEquipmentController(OfficeEquipmentService service, ILogger<OfficeEquipmentController> logger) : ControllerBase
{
    /// <summary>Список персональных компьютеров (nout=0).</summary>
    [HttpGet("computers")]
    [ProducesResponseType(typeof(List<OfficeComputerDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<ActionResult<List<OfficeComputerDto>>> GetComputers(CancellationToken ct = default)
    {
        try
        {
            var items = await service.GetByTypeAsync(0, ct);
            return Ok(items);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Не удалось получить список компьютеров с сервера ТЭЦ");
            return StatusCode(502, new { message = "Источник данных недоступен" });
        }
    }

    /// <summary>Список ноутбуков (nout=1).</summary>
    [HttpGet("laptops")]
    [ProducesResponseType(typeof(List<OfficeComputerDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<ActionResult<List<OfficeComputerDto>>> GetLaptops(CancellationToken ct = default)
    {
        try
        {
            var items = await service.GetByTypeAsync(1, ct);
            return Ok(items);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Не удалось получить список ноутбуков с сервера ТЭЦ");
            return StatusCode(502, new { message = "Источник данных недоступен" });
        }
    }
}