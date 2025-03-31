using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPITickets.Models
{
    public class Tiquetes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ti_identificador { get; set; }

        [Required]
        [StringLength(150)]
        public string ti_asunto { get; set; }

        [Required]
        [StringLength(150)]
        public string ti_categoria { get; set; }

        [Required]
        public int ti_us_id_asigna { get; set; }

        [Required]
        [StringLength(150)]
        public string ti_urgencia { get; set; }

        [Required]
        [StringLength(150)]
        public string ti_importancia { get; set; }

        [Required]
        [StringLength(1)]
        public string ti_estado { get; set; }

        [JsonIgnore]
        public DateTime ti_fecha_adicion { get; set; }

        [Required]
        [StringLength(10)]
        public string ti_adicionado_por { get; set; }

        [JsonIgnore]
        public DateTime? ti_fecha_modificacion { get; set; }

        [JsonIgnore]
        public string? ti_modificado_por { get; set; }
    }
}
