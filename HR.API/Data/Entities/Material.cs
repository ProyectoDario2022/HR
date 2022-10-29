using System.ComponentModel.DataAnnotations;

namespace HR.API.Data.Entities
{
    public class Material
    {
        public int Id { get; set; }
        // public string Tipo { get; set; }
        [Display(Name = "Descripcion")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Descripcion { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(20, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Nombre { get; set; }

        public List<Reclamo>? Reclamos { get; set; }
    }
}
