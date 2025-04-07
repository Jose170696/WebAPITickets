using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITickets.Database;
using WebAPITickets.Models;

namespace WebAPITickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ContextoBD _contexto;

        public CategoriasController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetCategorias()
        {
            return await _contexto.Categorias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categorias>> GetCategoriaById(int id)
        {
            var categoria = await _contexto.Categorias.FindAsync(id);
            if (categoria == null)
                return NotFound(new { mensaje = $"Categoría con ID {id} no encontrada." });

            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult<Categorias>> AddCategoria(Categorias nuevaCategoria)
        {
            try
            {
                _contexto.Categorias.Add(nuevaCategoria);
                await _contexto.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCategoriaById), new { id = nuevaCategoria.ca_identificador }, nuevaCategoria);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"Error al agregar la categoría: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, Categorias categoriaActualizada)
        {
            if (id != categoriaActualizada.ca_identificador)
                return BadRequest(new { mensaje = "El ID proporcionado no coincide con la categoría a actualizar." });

            _contexto.Entry(categoriaActualizada).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_contexto.Categorias.Any(e => e.ca_identificador == id))
                    return NotFound(new { mensaje = $"Categoría con ID {id} no encontrada." });

                throw;
            }
        }
    }
}