using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentilacionAPI.Models
{
    public class FlujoAire
    {
        [Key]
        public int FlujoAireId { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Valor { get; set; }

        public int OrificioVentilacionId { get; set; }
        public OrificioVentilacion OrificioVentilacion { get; set; }

        public int RegistroVentilacionId { get; set; }
        public RegistroVentilacion RegistroVentilacion { get; set; }
    }
}
