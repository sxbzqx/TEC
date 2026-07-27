using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tecBackend.Models;

namespace tecBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WorkersController : ControllerBase
    {
        private readonly SiteContext _context;

        public WorkersController(SiteContext context)
        {
            _context = context;
        }

        
        
        
        [HttpGet("birthdays")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Worker>>> GetBirthdays()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            
            var birthdays = await _context
                .Workers.Where(w =>
                    (w.Dr.Day == today.Day && w.Dr.Month == today.Month)
                    || (w.Dr.Day == tomorrow.Day && w.Dr.Month == tomorrow.Month)
                )
                .ToListAsync();

            return Ok(birthdays);
        }

        
        
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> GetWorkers()
        {
            return await _context.Workers.ToListAsync();
        }

        
        
        
        
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);

            if (worker == null)
            {
                return NotFound(new { message = "Сотрудник не найден" });
            }

            return worker;
        }

        
        
        
        
        [HttpPost]
        public async Task<ActionResult<Worker>> PostWorker(Worker worker)
        {
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorker), new { id = worker.Id }, worker);
        }
    }
}
