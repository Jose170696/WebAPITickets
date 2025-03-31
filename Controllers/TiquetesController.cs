using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITickets.Database;
using WebAPITickets.Models;

namespace WebAPITickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiquetesController : Controller
    {
        private readonly ContextoBD _contexto;

        public TiquetesController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        // Obtener todos los tiquetes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiquetes>>> GetTiquetes()
        {
            return await _contexto.Tiquetes.ToListAsync();
        }

        // Consultar tiquete por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Tiquetes>> GetTiqueteById(int id)
        {
            var tiquete = await _contexto.Tiquetes.FindAsync(id);

            if (tiquete == null)
            {
                return NotFound(new { mensaje = $"Tiquete con ID {id} no encontrado." });
            }

            return tiquete;
        }

        // Agregar un nuevo tiquete
        [HttpPost]
        public async Task<ActionResult<Tiquetes>> AddTiquete(Tiquetes nuevoTiquete)
        {
            try
            {
                nuevoTiquete.ti_fecha_adicion = DateTime.Now;
                _contexto.Tiquetes.Add(nuevoTiquete);
                await _contexto.SaveChangesAsync();
                return CreatedAtAction(nameof(GetTiqueteById), new { id = nuevoTiquete.ti_identificador }, nuevoTiquete);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"Error al agregar el tiquete: {ex.Message}" });
            }
        }

        // Actualizar un tiquete existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTiquete(int id, Tiquetes tiqueteActualizado)
        {
            if (id != tiqueteActualizado.ti_identificador)
            {
                return BadRequest(new { mensaje = "El ID proporcionado no coincide con el tiquete a actualizar." });
            }

            tiqueteActualizado.ti_fecha_modificacion = DateTime.Now;
            tiqueteActualizado.ti_modificado_por = tiqueteActualizado.ti_adicionado_por;

            _contexto.Entry(tiqueteActualizado).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiqueteExists(id))
                {
                    return NotFound(new { mensaje = $"Tiquete con ID {id} no encontrado." });
                }
                else
                {
                    throw;
                }
            }
        }

        private bool TiqueteExists(int id)
        {
            return _contexto.Tiquetes.Any(e => e.ti_identificador == id);
        }
    }
}