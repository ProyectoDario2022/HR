using System.ComponentModel.DataAnnotations;

namespace HR.API.Models
{
    public class ChangePasswordViewModel
    {

        [Display(Name = "Contraseña Actual")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "El Campo{0} debe tener una longitud minima de {1} carácteres.")]
        public string OldPassword { get; set; }



        [Display(Name = "Nueva Contraseña")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "El Campo{0} debe tener una longitud minima de {1} carácteres.")]
        public string NewPassword { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirmación de Contraseña")]
        [MinLength(6, ErrorMessage = "El Campo{0} debe tener una longitud minima de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        [Compare("NewPassword", ErrorMessage = "La Contraseña y Confirmación de contraseña no son iguales.")]
        public string Confirm { get; set; }
    }
}
