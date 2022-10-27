using HR.API.Data.Configure;
using HR.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<ReclamoType> ReclamoTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ConfigFuncion(modelBuilder.Entity<Funcion>());
            new ConfigMaterial(modelBuilder.Entity<Material>());
            new ConfigReclamoType(modelBuilder.Entity<ReclamoType>());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Funcion>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<Material>().HasIndex(x => x.Nombre).IsUnique();
            modelBuilder.Entity<ReclamoType>().HasIndex(x => x.Descripcion).IsUnique();


        }

    }
}
