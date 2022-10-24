using HR.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        public DbSet<ReclamoType> ReclamoTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ReclamoType>().HasIndex(x => x.Descripcion).IsUnique();
        }

    }
}
