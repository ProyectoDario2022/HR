using HR.API.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HR.API.Models
{
    public class ReclamoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Número de Reclamo")]
      //  [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public int Numero { get; set; }

       
        [Display(Name = "Tipo de Reclamo")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes Seleccionar Un Tipo de Reclamo")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public int ReclamoTypeId { get; set; }
        public IEnumerable<SelectListItem>? TipoReclamos { get; set; }

        [Display(Name = "Hora de Llegada")]
       // [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public DateTime? HLlegada { get; set; }

        [Display(Name = "Hora de Salida")]
       // [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public DateTime? HSalida { get; set; }

        [Display(Name = "Resolucion del Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        //[Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string? Resolucion { get; set; }

        [Display(Name = "Observacioes de Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string? Observaciones { get; set; }

       
        [Display(Name = "Tecnico asignado")]
        //[Range(1, int.MaxValue,ErrorMessage = "Debes Seleccionar Un Tecnico para el Reclamo")]//int.MaxValue
        [Required(ErrorMessage = "El campo{0} es obligatorio")]

        public string TecnicoId { get; set; }

        public IEnumerable<SelectListItem>? Tecnicos { get; set; }
     

        [Display(Name = "Abonado del Reclamo")]
      //  [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public int AbonadoId { get; set; }

        [Display(Name = "Fecha del Reclamo")]
        //[MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Materiales usados en el Reclamo")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes Seleccionar Un Material para el Reclamo")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]

        public int ReclamoMateriaId { get; set; }

        public IEnumerable<SelectListItem>? Materiales { get; set; }

        [Display(Name = "Comentario del Reclamo")]
        [MaxLength(50, ErrorMessage = "El campo{0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string? Comentario { get; set; }
    }
}
