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
    /// <summary>Список персональных компьютеров.</summary>
    [HttpGet("computers")]
    [ProducesResponseType(typeof(List<OfficeEquipment>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<OfficeEquipment>>> GetComputers(CancellationToken ct = default)
    {
        try
        {
            var items = await service.GetByTypeAsync("computer", ct);
            return Ok(items);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Не удалось получить список компьютеров из БД");
            return StatusCode(500, new { message = "Ошибка при получении данных из базы" });
        }
    }

    /// <summary>Список ноутбуков.</summary>
    [HttpGet("laptops")]
    [ProducesResponseType(typeof(List<OfficeEquipment>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<OfficeEquipment>>> GetLaptops(CancellationToken ct = default)
    {
        try
        {
            var items = await service.GetByTypeAsync("laptop", ct);
            return Ok(items);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Не удалось получить список ноутбуков из БД");
            return StatusCode(500, new { message = "Ошибка при получении данных из базы" });
        }
    }

    /// <summary>Список принтеров и оргтехники.</summary>
    [HttpGet("printers")]
    [ProducesResponseType(typeof(List<OfficeEquipment>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<OfficeEquipment>>> GetPrinters(CancellationToken ct = default)
    {
        try
        {
            var items = await service.GetByTypeAsync("printer", ct);
            return Ok(items);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Не удалось получить список принтеров из БД");
            return StatusCode(500, new { message = "Ошибка при получении данных из базы" });
        }
    }

    /// <summary>Список прочего оборудования (панели, проекторы и т.д.).</summary>
    [HttpGet("other")]
    [ProducesResponseType(typeof(List<OfficeEquipment>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<OfficeEquipment>>> GetOtherEquipment(CancellationToken ct = default)
    {
        try
        {
            var items = await service.GetByTypeAsync("other", ct);
            return Ok(items);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Не удалось получить список прочего оборудования из БД");
            return StatusCode(500, new { message = "Ошибка при получении данных из базы" });
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OfficeEquipment>> GetById(int id, CancellationToken ct)
    {
        var item = await service.GetByIdAsync(id, ct);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<OfficeEquipment>> Create([FromBody] OfficeEquipment entity, CancellationToken ct)
    {
        var created = await service.CreateAsync(entity, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<OfficeEquipment>> Update(int id, [FromBody] OfficeEquipment dto, CancellationToken ct)
    {
        var updated = await service.UpdateAsync(id, dto, ct);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id, CancellationToken ct)
    {
        var success = await service.DeleteAsync(id, ct);
        return success ? NoContent() : NotFound();
    }
}