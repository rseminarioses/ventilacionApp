using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentilacionAPI.Models
{
    public class RegistroVentilacion
    {
        [Key]
        public int RegistroVentilacionId { get; set; }

        public DateTime Fecha { get; set; }

        public List<FlujoAire> FlujosAire { get; set; }
    }
}
