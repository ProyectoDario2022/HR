using HR.API.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HR.API.Models
{
    public class UserViewModel:User
    {
        [Display(Name = "Foto")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Tipo de Funcion del Tecnico")]
        [Range(1,int.MaxValue,ErrorMessage = "Debes Seleccionar Una Funcion Tecnica")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]

        public int FuncionId { get; set; }

        public IEnumerable<SelectListItem> Funciones{ get; set; }
    }
}
