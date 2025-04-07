using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITickets.Database;
using WebAPITickets.Models;

namespace WebAPITickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportanciasController : ControllerBase
    {
        private readonly ContextoBD _contexto;

        public ImportanciasController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Importancias>>> GetImportancias()
        {
            return await _contexto.Importancias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Importancias>> GetImportanciaById(int id)
        {
            var importancia = await _contexto.Importancias.FindAsync(id);
            if (importancia == null)
                return NotFound(new { mensaje = $"Importancia con ID {id} no encontrada." });

            return importancia;
        }

        [HttpPost]
        public async Task<ActionResult<Importancias>> AddImportancia(Importancias nuevaImportancia)
        {
            try
            {
                _contexto.Importancias.Add(nuevaImportancia);
                await _contexto.SaveChangesAsync();
                return CreatedAtAction(nameof(GetImportanciaById), new { id = nuevaImportancia.im_identificador }, nuevaImportancia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"Error al agregar la importancia: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImportancia(int id, Importancias importanciaActualizada)
        {
            if (id != importanciaActualizada.im_identificador)
                return BadRequest(new { mensaje = "El ID proporcionado no coincide con la importancia a actualizar." });

            _contexto.Entry(importanciaActualizada).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_contexto.Importancias.Any(e => e.im_identificador == id))
                    return NotFound(new { mensaje = $"Importancia con ID {id} no encontrada." });

                throw;
            }
        }
    }
}
