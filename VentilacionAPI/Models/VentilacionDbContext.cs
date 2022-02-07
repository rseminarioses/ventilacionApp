using Microsoft.EntityFrameworkCore;
using VentilacionAPI.Models;

namespace VentilacionAPI.Models
{
    public class VentilacionDbContext:DbContext
    {        
        public VentilacionDbContext(DbContextOptions<VentilacionDbContext> options):base(options)
        {

        }

        public DbSet<Sede> Sede{ get; set; }
        public DbSet<Habitacion> Habitacion { get; set; }        
        public DbSet<OrificioVentilacion> OrificioVentilacion { get; set; }
        public DbSet<FlujoAire> FlujoAire { get; set; }
        public DbSet<VentilacionAPI.Models.RegistroVentilacion> RegistroVentilacion { get; set; }
    }
}
