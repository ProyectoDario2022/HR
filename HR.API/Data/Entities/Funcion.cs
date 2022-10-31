using System.ComponentModel.DataAnnotations;

namespace HR.API.Data.Entities
{
    public class Funcion
    {
        public int Id { get; set; }
        // public string Tipo { get; set; }
        [Display(Name = "Tipo de Funcion")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Descripcion { get; set; }
        public List<User>? Tecnicos { get; set; }
    }
}
