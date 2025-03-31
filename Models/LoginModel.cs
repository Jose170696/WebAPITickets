using System.ComponentModel.DataAnnotations;

namespace WebAPITickets.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(150)]
        public string us_correo { get; set; }

        [Required]
        [StringLength(255)]
        public string us_clave { get; set; }
    }
}
