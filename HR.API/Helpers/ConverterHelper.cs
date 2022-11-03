using HR.API.Data;
using HR.API.Data.Entities;
using HR.API.Models;

namespace HR.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
        public async Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew)
        {
            return new User
            {
                Direccion = model.Direccion,
                Document = model.Document,
                Funcion = await _context.Funciones.FindAsync(model.FuncionId),
                Email = model.Email,
                Id = isNew ? Guid.NewGuid().ToString() : model.Id,
                ImageId = imageId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Email,
                UserType = model.UserType,
                ReclamoTecnicos = model.ReclamoTecnicos,

            };
        }

        public UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Direccion = user.Direccion,
                Document = user.Document,
                Funcion = user.Funcion,
                FuncionId = user.Funcion.Id,
                Funciones = _combosHelper.GetComboFunciones(),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.Email,
                UserType = user.UserType,
                ReclamoTecnicos = user.ReclamoTecnicos,
            };
        }
    }
}
