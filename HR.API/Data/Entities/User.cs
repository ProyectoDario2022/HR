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
           : $"https://drive.internxt.com/s/file/6f2762e72b058181bf24/daa17bd41f9585410ae83a3960664a9f47647ee46d10e2c43a737be3e0511985/{ImageId}";
            
           // : $"https://localhost:7053/users/{ImageId}";

        [Display(Name = "Tipo De Usuario")]
        public UserType UserType { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName}{LastName}";


        public Funcion? Funcion { get; set; }
        public List<ReclamoTecnico>? ReclamoTecnicos { get; set; }
        [Display(Name = "# Reclamos")]
        public int reclamosCount => ReclamoTecnicos == null ? 0 : ReclamoTecnicos.Count;



    }
}
