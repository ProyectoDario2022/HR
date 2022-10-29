namespace HR.API.Data.Entities
{
    public class Reclamo
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public ReclamoType? Tipo { get; set; }
        public DateTime? HLlegada { get; set; }
        public DateTime? HSalida { get; set; }
        public string? Resolucion { get; set; }
        public string? Observaciones { get; set; }
        public List<ReclamoTecnico>? ReclamoTecnicos { get; set; }

        public Abonado? Abonado { get; set; }
        public DateTime Fecha { get; set; }
        public List<ReclamoMaterial>? ReclamoMateriales { get; set; }
        public string? Comentario { get; set; }
    }
}
