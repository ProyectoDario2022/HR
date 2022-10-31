using HR.Common.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HR.API.Data.Entities
{
    public class User : IdentityUser
    {
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

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }


        //TODO:Fix the images path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7053/images/noimage.png"
            : $"https://localhost:7053/users/{ImageId}";

        [Display(Name = "Tipo De Usuario")]
        public UserType UserType { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName}{LastName}";


    }
}
