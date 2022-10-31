using HR.API.Data.Entities;
using HR.API.Helpers;
using HR.Common.Enums;

namespace HR.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context,IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();//crea la base de datos y corre las migraciones, es como update-database
            await CheckReclamoType();
            await CheckFuncion();
            await CheckMaterial();
            await CheckRolesAsync();
            await CheckUserAsync("23234543", "Dario", "Paez", "prueba1@gmail.com", "1234567890", "callao 10", UserType.Admin);
            await CheckUserAsync("23234043", "Esteban", "Diaz", "prueba2@gmail.com", "1234567890", "callao 1", UserType.User);
            await CheckUserAsync("23234583", "Matias", "Ques", "prueba3@gmail.com", "1234567890", "callao 14", UserType.User);
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firsName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user=await _userHelper.GetUserAsync(email);
            if(user==null)
            {
                user = new User
                {   UserName = email,
                    Document = document,
                    FirstName = firsName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phone,
                    Direccion = address,
                    UserType = userType,

                };
                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

            }
            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckMaterial()
        {
            if (!_context.Materiales.Any())
            {
                _context.Materiales.Add(new Material { Descripcion = "Rg59", Nombre = "RG 59" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckFuncion()
        {
            if (!_context.Funciones.Any())
            {
                _context.Funciones.Add(new Funcion { Descripcion = "Instalador" });
                _context.Funciones.Add(new Funcion { Descripcion = "Service", });
                _context.Funciones.Add(new Funcion { Descripcion = "Red" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckReclamoType()
        {
            if (!_context.ReclamoTypes.Any())
            {
                _context.ReclamoTypes.Add(new ReclamoType{ Descripcion = "Instalacion" });
                _context.ReclamoTypes.Add(new ReclamoType { Descripcion = "Service", });
                _context.ReclamoTypes.Add(new ReclamoType { Descripcion = "Red" });
                _context.ReclamoTypes.Add(new ReclamoType { Descripcion = "Reinstalacion" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
