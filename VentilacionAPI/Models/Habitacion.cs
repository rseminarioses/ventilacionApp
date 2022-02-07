using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentilacionAPI.Models
{
    public class Habitacion
    {
        [Key]
        public int HabitacionId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Ancho { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Alto { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Largo { get; set; }

        public int SedeId { get; set; }
        public Sede Sede { get; set; }        
    }
}
