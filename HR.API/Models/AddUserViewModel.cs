using System.ComponentModel.DataAnnotations;

namespace HR.API.Models
{
    public class AddUserViewModel:EditUserViewModel
    {
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debes instroducir un Email Válido")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Username { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [MinLength(6,ErrorMessage = "El Campo{0} debe tener una longitud minima de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirmación de Contraseña")]
        [MinLength(6, ErrorMessage = "El Campo{0} debe tener una longitud minima de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        [Compare("Password",ErrorMessage ="La Contraseña y Confirmación de contraseña no son iguales.")]
        public string PasswordConfirm { get; set; }
    }
}
