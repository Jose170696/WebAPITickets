using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPITickets.Models
{
    public class Usuarios
    {
        [Key]
        public int UsIdentificador { get; set; }

        [Required, StringLength(150)]
        public string UsNombreCompleto { get; set; }

        [Required, StringLength(150)]
        public string UsCorreo { get; set; }

        [Required, StringLength(255)]
        public string UsClave { get; set; }

        [Required]
        public int UsRoIdentificador { get; set; }

        [ForeignKey("UsRoIdentificador")]
        public Roles Rol { get; set; }

        [Required, StringLength(1)]
        public string UsEstado { get; set; }

        [Required]
        public DateTime UsFechaAdicion { get; set; } = DateTime.Now;

        [Required, StringLength(10)]
        public string UsAdicionadoPor { get; set; }

        public DateTime? UsFechaModificacion { get; set; }

        [StringLength(10)]
        public string UsModificadoPor { get; set; }
    }
}
