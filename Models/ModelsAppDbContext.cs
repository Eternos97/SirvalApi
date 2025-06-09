

namespace SirvalApi.Models
{
    using Microsoft.EntityFrameworkCore;

    namespace SirvalApi.Data
    {
        // Contexto de base de datos que representa una sesión con la base de datos
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Dispositivo> Dispositivos { get; set; }
            public DbSet<Alerta> Alertas { get; set; }
            public DbSet<Responsable> Responsables { get; set; }
            public DbSet<TipoAlerta> TiposAlerta { get; set; }
            public DbSet<Asignacion> Asignaciones { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            }
        }
    }
}