using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPITickets.Models
{
    public class Importancias
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int im_identificador { get; set; }

        [Required]
        [MaxLength(125)]
        public string im_nivel { get; set; }
    }
}
