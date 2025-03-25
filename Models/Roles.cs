using System.ComponentModel.DataAnnotations;

namespace WebAPITickets.Models
{
    public class Roles
    {
        [Key]
        public int ro_identificador { get; set; }

        [Required, StringLength(125)]
        public string ro_descripcion { get; set; }

        [Required]
        public DateTime ro_fecha_adicion { get; set; } = DateTime.Now;

        [Required, StringLength(10)]
        public string ro_adicionado_por { get; set; }

        public DateTime? ro_fecha_modificacion { get; set; }

        [StringLength(10)]
        public string ro_modificado_por { get; set; }
    }
}
