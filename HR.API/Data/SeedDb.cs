using HR.API.Data.Entities;

namespace HR.API.Data
{/*
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckReclamoTypeAsync();
            await CheckFuncionAsync();
            await CheckMaterialAsync();
        }

        private async Task CheckMaterialAsync()
        {
            if (!_context.Materiales.Any())
            {
                _context.Materiales.Add(new Material { Descripcion = "Conector RG59",Nombre="RG 59" });
                _context.Materiales.Add(new Material { Descripcion = "Conector RG6", Nombre = "RG 6" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckFuncionAsync()
        {
            if (!_context.Materiales.Any())
            {
                _context.Funciones.Add(new Funcion { Descripcion = "Instalador" });
                _context.Funciones.Add(new Funcion { Descripcion = "Service" });
                _context.Funciones.Add(new Funcion { Descripcion = "Red" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckReclamoTypeAsync()
        {
            if(!_context.ReclamoTypes.Any())
            {
                _context.ReclamoTypes.Add(new ReclamoType { Descripcion = "Instalacion" });
                _context.ReclamoTypes.Add(new ReclamoType { Descripcion = "Service" });
                _context.ReclamoTypes.Add(new ReclamoType { Descripcion = "Red" });
                _context.ReclamoTypes.Add(new ReclamoType { Descripcion = "Reinstalacion" });
                await _context.SaveChangesAsync();
            }
        }
    }*/
}
