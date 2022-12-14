using System.ComponentModel.DataAnnotations;

namespace HR.API.Data.Entities
{
    public class ReclamoType
    {
        public int Id { get; set; }
       // public string Tipo { get; set; }
       [Display(Name="Tipo de Reclamo")]
       [MaxLength(50,ErrorMessage= "El campo{0} no puede tener mas de {1} carácteres")]
       [Required(ErrorMessage ="El campo{0} es obligatorio")]
        public string Descripcion { get; set; }
        public ICollection<Reclamo>? Reclamos { get; set; }
    }
}
