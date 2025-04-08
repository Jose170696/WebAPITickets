using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITickets.Database;
using WebAPITickets.Models;

namespace WebAPITickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly ContextoBD _contexto;

        public RolesController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        // Obtener todos los roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRol()
        {
            return await _contexto.Roles.ToListAsync();
        }

        // Consultar rol por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRolById(int id)
        {
            var rol = await _contexto.Roles.FindAsync(id);

            if (rol == null)
            {
                return NotFound(new { mensaje = $"Rol con ID {id} no encontrado." });
            }

            return rol;
        }

        // Agregar un nuevo rol
        [HttpPost("registrar")]
        public async Task<ActionResult<Roles>> AddRol(Roles nuevoRol)
        {
            try
            {
                // Asignar la fecha de adición automáticamente
                nuevoRol.ro_fecha_adicion = DateTime.Now;

                _contexto.Roles.Add(nuevoRol);
                await _contexto.SaveChangesAsync();
                return CreatedAtAction(nameof(GetRolById), new { id = nuevoRol.ro_identificador }, nuevoRol);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"Error al agregar el rol: {ex.Message}" });
            }
        }

        // Actualizar un rol existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRol(int id, Roles rolActualizado)
        {
            if (id != rolActualizado.ro_identificador)
            {
                return BadRequest(new { mensaje = "El ID proporcionado no coincide con el rol a actualizar." });
            }

            rolActualizado.ro_fecha_modificacion = DateTime.Now;
            rolActualizado.ro_modificado_por = rolActualizado.ro_adicionado_por;
            _contexto.Entry(rolActualizado).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
                {
                    return NotFound(new { mensaje = $"Rol con ID {id} no encontrado." });
                }
                else
                {
                    throw;
                }
            }
        }

        private bool RolExists(int id)
        {
            return _contexto.Roles.Any(e => e.ro_identificador == id);
        }
    }
}
