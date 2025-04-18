﻿using System.ComponentModel.DataAnnotations.Schema;
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

        public int ti_ca_id { get; set; }

        public int ti_us_id_asigna { get; set; }

        public int ti_ur_id { get; set; }

        public int ti_im_id { get; set; }

        [Required]
        [StringLength(1)]
        public string ti_estado { get; set; }

        [Required]
        [StringLength(150)]
        public string ti_solucion { get; set; }

        [JsonIgnore]
        public DateTime ti_fecha_adicion { get; set; } = DateTime.Now;

        [Required]
        [StringLength(10)]
        public string ti_adicionado_por { get; set; }

        [JsonIgnore]
        public DateTime? ti_fecha_modificacion { get; set; }

        [JsonIgnore]
        public string? ti_modificado_por { get; set; }
    }
}
