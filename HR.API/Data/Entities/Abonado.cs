using System.ComponentModel.DataAnnotations;

namespace HR.API.Data.Entities
{
    public class Abonado
    {
        public int Id { get; set; }
        [Display(Name = "Numero de Cliente")]
        [MaxLength(20, ErrorMessage = "El Campo {0}no puede tener mas de{1} Carácteres.")]

        public int Numero { get; set; }
        [Display(Name = "Numero de DNI")]
        [MaxLength(20, ErrorMessage = "El Campo {0}no puede tener mas de{1} Carácteres.")]

        public int DNI { get; set; }
        [Display(Name = "Nombre del Abonado")]
        [MaxLength(25, ErrorMessage = "El Campo {0}no puede tener mas de{1} Carácteres.")]

        public string Nombre { get; set; }
        [Display(Name = "Apellido del Abonado")]
        [MaxLength(25, ErrorMessage = "El Campo {0}no puede tener mas de{1} Carácteres.")]
        public string Apellido { get; set; }
        [Display(Name = "Domicilio del Abonado")]
        [MaxLength(25, ErrorMessage = "El Campo {0}no puede tener mas de{1} Carácteres.")]
        public string Domicilio { get; set; }
        [Display(Name = "Sector a Donde pertenece el Abonado")]
        [MaxLength(25, ErrorMessage = "El Campo {0}no puede tener mas de{1} Carácteres.")]
        public string Sector { get; set; }
        public List<Reclamo>? Reclamos { get; set; }
    }
}
