using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SirvalApi.Models;
using SirvalApi.Models.SirvalApi.Data;

namespace SirvalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposAlertaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TiposAlertaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoAlerta>>> Get()
        {
            return await _context.TiposAlerta.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAlerta>> Get(int id)
        {
            var tipo = await _context.TiposAlerta.FindAsync(id);
            return tipo == null ? NotFound() : tipo;
        }

        [HttpPost]
        public async Task<ActionResult<TipoAlerta>> Post([FromBody] TipoAlerta tipo)
        {
            _context.TiposAlerta.Add(tipo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = tipo.Id_TipoAlerta }, tipo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TipoAlerta tipo)
        {
            if (id != tipo.Id_TipoAlerta) return BadRequest();
            _context.Entry(tipo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipo = await _context.TiposAlerta.FindAsync(id);
            if (tipo == null) return NotFound();
            _context.TiposAlerta.Remove(tipo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}