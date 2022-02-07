using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentilacionAPI.Models
{
    public class OrificioVentilacion
    {
        [Key]
        public int OrificioVentilacionId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Ubicacion { get; set; }

        public decimal Ancho { get; set; }
        
        public decimal Alto { get; set; }        

        public int HabitacionId { get; set; }
        public Habitacion Habitacion { get; set; }        
    }
}
