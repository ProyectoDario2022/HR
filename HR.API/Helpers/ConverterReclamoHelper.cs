using HR.API.Data;
using HR.API.Data.Entities;
using HR.API.Models;

namespace HR.API.Helpers
{
    public class ConverterReclamoHelper : IConverterReclamoHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterReclamoHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
        public async Task<Reclamo> ToReclamoAsync(ReclamoViewModel model, bool isNew)
        {
            Abonado abonado = new Abonado
            {
                Numero = model.AbonadoId,
                DNI = 0,
                Nombre=" ",
                Apellido=" ",
                Domicilio=" ",
                Sector=" ",
    };
            
            return new Reclamo
            { 
                Numero = model.Numero,
                TipoReclamo = await _context.ReclamoTypes.FindAsync(model.ReclamoTypeId),
                HLlegada=model.HLlegada,
                HSalida = model.HSalida,
                Resolucion=model.Resolucion,
                Observaciones=model.Observaciones,
                Fecha=model.Fecha,
                Comentario=model.Comentario,
                Abonado=abonado,
     
            };
        }

        public ReclamoViewModel ToReclamoViewModel(Reclamo reclamo)
        {
            return new ReclamoViewModel
            {/*
                Direccion = user.Direccion,
                Document = user.Document,
                //Funcion = user.Funcion,
                FuncionId = user.Funcion.Id,
                Funciones = _combosHelper.GetComboFunciones(),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                ImageId=user.ImageId,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.Email,
                UserType = user.UserType,
                ReclamoTecnicos = user.ReclamoTecnicos,
                */
            };
        }
    }
}
