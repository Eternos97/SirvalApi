using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirvalApi.Models;
using SirvalApi.Models.SirvalApi.Data;

namespace SirvalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AsignacionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignacion>>> Get()
        {
            return await _context.Asignaciones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asignacion>> Get(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            return asignacion == null ? NotFound() : asignacion;
        }

        [HttpPost]
        public async Task<ActionResult<Asignacion>> Post([FromBody] Asignacion asignacion)
        {
            asignacion.Fecha_Asig = DateTime.Now;
            asignacion.Estado_Asig = "Pendiente";
            _context.Asignaciones.Add(asignacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = asignacion.Id_Asignacion }, asignacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Asignacion asignacion)
        {
            if (id != asignacion.Id_Asignacion) return BadRequest();
            _context.Entry(asignacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null) return NotFound();
            _context.Asignaciones.Remove(asignacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
