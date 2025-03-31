using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITickets.Database;
using WebAPITickets.Models;

namespace WebAPITickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly ContextoBD _contexto;

        public UsuariosController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        // Obtener todos los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            return await _contexto.Usuarios.ToListAsync();
        }

        // Consultar usuario por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarioById(int id)
        {
            var usuario = await _contexto.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(new { mensaje = $"Usuario con ID {id} no encontrado." });
            }

            return usuario;
        }

        // Agregar un nuevo usuario
        [HttpPost]
        public async Task<ActionResult<Usuarios>> AddUsuario(Usuarios nuevoUsuario)
        {
            try
            {
                nuevoUsuario.us_fecha_adicion = DateTime.Now;
                _contexto.Usuarios.Add(nuevoUsuario);
                await _contexto.SaveChangesAsync();
                return CreatedAtAction(nameof(GetUsuarioById), new { id = nuevoUsuario.us_identificador }, nuevoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"Error al agregar el usuario: {ex.Message}" });
            }
        }

        // Actualizar un usuario existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuarios usuarioActualizado)
        {
            if (id != usuarioActualizado.us_identificador)
            {
                return BadRequest(new { mensaje = "El ID proporcionado no coincide con el usuario a actualizar." });
            }

            usuarioActualizado.us_fecha_modificacion = DateTime.Now;
            usuarioActualizado.us_modificado_por = usuarioActualizado.us_adicionado_por;

            _contexto.Entry(usuarioActualizado).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound(new { mensaje = $"Usuario con ID {id} no encontrado." });
                }
                else
                {
                    throw;
                }
            }
        }

        private bool UsuarioExists(int id)
        {
            return _contexto.Usuarios.Any(e => e.us_identificador == id);
        }
    }
}