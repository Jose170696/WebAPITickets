using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPITickets.Models
{
    public class Urgencias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ur_identificador { get; set; }

        [Required]
        [MaxLength(125)]
        public string ur_nivel { get; set; }
    }
}
