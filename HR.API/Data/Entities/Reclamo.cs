using System.ComponentModel.DataAnnotations;

namespace HR.API.Data.Entities
{
    public class Reclamo
    {
        public int Id { get; set; }

        [Display(Name = "Número de Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public int Numero { get; set; }

        [Display(Name = "Tipo de Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public ReclamoType? TipoReclamo { get; set; }

        [Display(Name = "Hora de Llegada")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public DateTime? HLlegada { get; set; }

        [Display(Name = "Hora de Salida")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public DateTime? HSalida { get; set; }

        [Display(Name = "Resolucion del Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string? Resolucion { get; set; }

        [Display(Name = "Observacioes de Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string? Observaciones { get; set; }

        [Display(Name = "Lista de Tecnicos asignados al Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public List<ReclamoTecnico>? ReclamoTecnicos { get; set; }

        [Display(Name = "Abonado del Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public Abonado? Abonado { get; set; }

        [Display(Name = "Fecha del Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Lista de Materiales usados en el Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public List<ReclamoMaterial>? ReclamoMateriales { get; set; }

        [Display(Name = "Comentario del Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string? Comentario { get; set; }

    }
}
