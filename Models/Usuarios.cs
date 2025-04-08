﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPITickets.Models
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int us_identificador { get; set; }

        [Required]
        [StringLength(150)]
        public string us_nombre_completo { get; set; }

        [Required]
        [StringLength(150)]
        public string us_correo { get; set; }

        [Required]
        [StringLength(255)]
        public string us_clave { get; set; }

        public int us_ro_identificador { get; set; }

        [Required]
        [StringLength(1)]
        public string us_estado { get; set; }

        [JsonIgnore]
        public DateTime us_fecha_adicion { get; set; } = DateTime.Now;

        [Required]
        [StringLength(10)]
        public string us_adicionado_por { get; set; }

        [JsonIgnore]
        public DateTime? us_fecha_modificacion { get; set; }

        [JsonIgnore]
        public string? us_modificado_por { get; set; }
    }
}
