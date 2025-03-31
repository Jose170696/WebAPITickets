using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPITickets.Models
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ro_identificador { get; set; }

        [Required]
        [MaxLength(125)]
        public string ro_descripcion { get; set; }

        [JsonIgnore]
        public DateTime ro_fecha_adicion { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(10)]
        public string ro_adicionado_por { get; set; }

        [JsonIgnore]
        public DateTime? ro_fecha_modificacion { get; set; }

        [JsonIgnore]
        public string? ro_modificado_por { get; set; }
    }
}
