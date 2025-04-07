using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITickets.Database;
using WebAPITickets.Models;

namespace WebAPITickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrgenciasController : ControllerBase
    {
        private readonly ContextoBD _contexto;

        public UrgenciasController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Urgencias>>> GetUrgencias()
        {
            return await _contexto.Urgencias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Urgencias>> GetUrgenciaById(int id)
        {
            var urgencia = await _contexto.Urgencias.FindAsync(id);
            if (urgencia == null)
                return NotFound(new { mensaje = $"Urgencia con ID {id} no encontrada." });

            return urgencia;
        }

        [HttpPost]
        public async Task<ActionResult<Urgencias>> AddUrgencia(Urgencias nuevaUrgencia)
        {
            try
            {
                _contexto.Urgencias.Add(nuevaUrgencia);
                await _contexto.SaveChangesAsync();
                return CreatedAtAction(nameof(GetUrgenciaById), new { id = nuevaUrgencia.ur_identificador }, nuevaUrgencia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"Error al agregar la urgencia: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUrgencia(int id, Urgencias urgenciaActualizada)
        {
            if (id != urgenciaActualizada.ur_identificador)
                return BadRequest(new { mensaje = "El ID proporcionado no coincide con la urgencia a actualizar." });

            _contexto.Entry(urgenciaActualizada).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_contexto.Urgencias.Any(e => e.ur_identificador == id))
                    return NotFound(new { mensaje = $"Urgencia con ID {id} no encontrada." });

                throw;
            }
        }
    }
}