using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirvalApi.Models;
using SirvalApi.Models.SirvalApi.Data;

namespace SirvalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsablesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResponsablesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Responsable>>> Get()
        {
            return await _context.Responsables.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Responsable>> Get(int id)
        {
            var responsable = await _context.Responsables.FindAsync(id);
            return responsable == null ? NotFound() : responsable;
        }

        [HttpPost]
        public async Task<ActionResult<Responsable>> Post([FromBody] Responsable responsable)
        {
            _context.Responsables.Add(responsable);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = responsable.Id_Responsable }, responsable);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Responsable responsable)
        {
            if (id != responsable.Id_Responsable) return BadRequest();
            _context.Entry(responsable).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var responsable = await _context.Responsables.FindAsync(id);
            if (responsable == null) return NotFound();
            _context.Responsables.Remove(responsable);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}