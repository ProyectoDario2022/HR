using HR.API.Data.Entities;
using HR.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HR.API.Models
{
    public class UserViewModel:User
    {
        public string Id { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debes instroducir un Email Válido")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Email { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string LastName { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Document { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(100, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(20, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }
                   

        [Display(Name = "Tipo De Usuario")]
        public UserType UserType { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName}{LastName}";

        [Display(Name = "Foto")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Tipo de Funcion del Tecnico")]
        [Range(1,int.MaxValue,ErrorMessage = "Debes Seleccionar Una Funcion Tecnica")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]

        public int FuncionId { get; set; }

        public IEnumerable<SelectListItem>? Funciones{ get; set; }
    }
}
