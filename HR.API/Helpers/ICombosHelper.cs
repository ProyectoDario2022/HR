using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR.API.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboFunciones();
        IEnumerable<SelectListItem> GetComboTipodeReclamos();
        IEnumerable<SelectListItem> GetComboMateriales();
        IEnumerable<SelectListItem> GetComboTecnicos();

    }
}
