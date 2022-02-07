using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentilacionAPI.Models
{
    public class Sede
    {
        [Key]
        public int SedeId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
    }
}
