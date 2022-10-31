using HR.API.Data.Configure;
using HR.API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Data
{
    public class DataContext:IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<ReclamoType> ReclamoTypes { get; set; }
        public DbSet<Abonado> Abonados { get; set; }
        public DbSet<Reclamo> Reclamos { get; set; }
        public DbSet<ReclamoMaterial> ReclamoMateriales { get; set; }
        public DbSet<ReclamoTecnico> reclamoTecnicos { get; set; }
       // public DbSet<Tecnico> Tecnicos { get; set; }
       


        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  new ConfigFuncion(modelBuilder.Entity<Funcion>());
          //  new ConfigMaterial(modelBuilder.Entity<Material>());
          //  new ConfigReclamoType(modelBuilder.Entity<ReclamoType>());
           // new ConfigUser(modelBuilder.Entity<User>());

                      
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Funcion>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<Material>().HasIndex(x => x.Nombre).IsUnique();
            modelBuilder.Entity<ReclamoType>().HasIndex(x => x.Descripcion).IsUnique();

            modelBuilder.Entity<Abonado>().HasIndex(x => x.Numero).IsUnique();
            modelBuilder.Entity<Reclamo>().HasIndex(x => x.Numero).IsUnique();
            modelBuilder.Entity<Tecnico>().HasIndex(x => x.Document).IsUnique();
           
            modelBuilder.Entity<ReclamoMaterial>().HasKey(x => new { x.ReclamoId, x.MaterialId });//muchos a muchos
            modelBuilder.Entity<ReclamoTecnico>().HasKey(x => new { x.ReclamoId, x.UserId });//muchos a muchos
        }

    }
}
