using System.ComponentModel.DataAnnotations;

namespace HR.API.Data.Entities
{
    public class Tecnico:User
    {
        public int Id { get; set; }
        public Funcion? Funcion { get; set; }
        public List<ReclamoTecnico>? ReclamoTecnicos { get; set; }
        [Display(Name ="# Reclamos")]
        public int reclamosCount=>ReclamoTecnicos==null? 0:ReclamoTecnicos.Count;
    }
}
