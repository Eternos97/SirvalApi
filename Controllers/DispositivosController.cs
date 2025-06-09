using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirvalApi.Models;
using SirvalApi.Models.SirvalApi.Data;

namespace SirvalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DispositivosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dispositivo>>> Get()
        {
            return await _context.Dispositivos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dispositivo>> Get(int id)
        {
            var dispositivo = await _context.Dispositivos.FindAsync(id);
            return dispositivo == null ? NotFound() : dispositivo;
        }

        [HttpPost]
        public async Task<ActionResult<Dispositivo>> Post([FromBody] Dispositivo dispositivo)
        {
            _context.Dispositivos.Add(dispositivo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = dispositivo.Id_Dispositivo }, dispositivo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Dispositivo dispositivo)
        {
            if (id != dispositivo.Id_Dispositivo) return BadRequest();
            _context.Entry(dispositivo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dispositivo = await _context.Dispositivos.FindAsync(id);
            if (dispositivo == null) return NotFound();
            _context.Dispositivos.Remove(dispositivo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}