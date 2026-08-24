using Microsoft.AspNetCore.Mvc;

namespace tecBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeController : ControllerBase
{
    
    [HttpGet]
    public IActionResult GetCurrentTime()
    {
        
        
        var currentTime = DateTime.UtcNow;

        return Ok(new { Message = "Текущее время получено", Time = currentTime });
    }
}
