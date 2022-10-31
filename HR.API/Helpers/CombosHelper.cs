using HR.API.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetComboFunciones()
        {
            List<SelectListItem> list = _context.Funciones.Select(x => new SelectListItem
            {
                Text=x.Descripcion,
                Value=$"{x.Id}"
            }).OrderBy(x => x.Text)
              .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una Funcion.]",
                Value = "0"

            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboMateriales()
        {
            List<SelectListItem> list = _context.Materiales.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = $"{x.Id}"
            }).OrderBy(x => x.Text)
              .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Material.]",
                Value = "0"

            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboTecnicos()
        {
            List<SelectListItem> list = _context.Tecnicos.Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = $"{x.Id}"
            }).OrderBy(x => x.Text)
              .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Tecnico.]",
                Value = "0"

            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboTipodeReclamos()
        {
            List<SelectListItem> list = _context.ReclamoTypes.Select(x => new SelectListItem
            {
                Text = x.Descripcion,
                Value = $"{x.Id}"
            }).OrderBy(x => x.Text)
              .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de reclamo.]",
                Value = "0"

            });
            return list;
        }
    }
}
