using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirvalApi.Models;
using SirvalApi.Models.SirvalApi.Data;

namespace SirvalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlertasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alerta>>> Get()
        {
            return await _context.Alertas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alerta>> Get(int id)
        {
            var alerta = await _context.Alertas.FindAsync(id);
            return alerta == null ? NotFound() : alerta;
        }

        [HttpPost]
        public async Task<ActionResult<Alerta>> Post([FromBody] Alerta alerta)
        {
            alerta.Fecha_Alerta = DateTime.Now;
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = alerta.Id_Alerta }, alerta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alerta alerta)
        {
            if (id != alerta.Id_Alerta) return BadRequest();
            _context.Entry(alerta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var alerta = await _context.Alertas.FindAsync(id);
            if (alerta == null) return NotFound();
            _context.Alertas.Remove(alerta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}