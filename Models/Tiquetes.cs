using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPITickets.Models
{
    public class Tiquetes
    {
        [Key]
        public int TiIdentificador { get; set; }

        [Required, StringLength(150)]
        public string TiAsunto { get; set; }

        [Required, StringLength(150)]
        public string TiCategoria { get; set; }

        [Required]
        public int TiUsIdAsigna { get; set; }

        [ForeignKey("TiUsIdAsigna")]
        public Usuarios Usuario { get; set; }

        [Required, StringLength(150)]
        public string TiUrgencia { get; set; }

        [Required, StringLength(150)]
        public string TiImportancia { get; set; }

        [Required, StringLength(1)]
        public string TiEstado { get; set; }

        [Required, StringLength(255)]
        public string TiSolucion { get; set; }

        [Required]
        public DateTime TiFechaAdicion { get; set; } = DateTime.Now;

        [Required, StringLength(10)]
        public string TiAdicionadoPor { get; set; }

        public DateTime? TiFechaModificacion { get; set; }

        [StringLength(10)]
        public string TiModificadoPor { get; set; }
    }
}
