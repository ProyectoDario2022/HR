namespace HR.API.Data.Entities
{
    public class ReclamoTecnico
    {
        public int ReclamoId { get; set; }
        public int TecnicoId { get; set; }

        public Tecnico Tecnico { get; set; }
       
        public Reclamo Reclamo { get; set; }
    }
}
